from PIL import Image
from PIL import ImageDraw
import sys
import os.path
import os
from subprocess import check_call

def getOutFilename(j,i):
  return "out%x-%03d.png"%(j,i)

def upper(b): return (b&0xF0) >> 4
def lower(b): return b&0x0F
def SprDec(source):
  temp = []
  # Build a list of ints from the nibbles
  for i in range(len(source)):
    temp.append(upper(ord(source[i])))
    temp.append(lower(ord(source[i])))
  i = 0
  result = []
  while i < len(temp):
    if temp[i] != 0:
      result.append(temp[i])
    elif (i + 1) < len(temp):
      s = temp[i+1]
      l = s
      if s == 0 and (i + 2) < len(temp): 
        l = temp[i+2]
        i += 1
      elif s == 7 and (i + 3) < len(temp): 
        l = temp[i+2] + (temp[i+3] << 4)
        i += 2
      elif s == 8 and (i + 4) < len(temp): 
        l = temp[i+2] + (temp[i+3] << 4) + (temp[i+4] << 8)
        i += 3
      i += 1
      # pad a bunch of 0's
      for j in range(l): result.append(0)
    i += 1
  i = 0
  # flip each pair of bytes
  while (i+1) < len(result):
    j = result[i]
    result[i] = result[i+1]
    result[i+1] = j
    i += 2
  return result

def getRGB(bytes):
  b = (ord(bytes[1]) & 0x7C) << 1
  g = ((ord(bytes[1]) & 0x03) << 6) | ((ord(bytes[0]) & 0xE0) >> 2)
  r = (ord(bytes[0]) & 0x1F) << 3
  a = 255
  return (r,g,b,a)

def buildPalette(bytes):
  colors = []
  for i in range(16):
    colors.insert(len(colors), getRGB(bytes[i*2:i*2+2]))
  if colors[0] == (0,0,0,255):
    colors[0] = (0,0,0,0)
  return colors

def buildPixels(bytes):
  result=[]
  for b in bytes:
    result.append(lower(ord(b)))
    result.append(upper(ord(b)))
  return result

emptyPalette = [(0,0,0,0),(0,0,0,255),(0,0,0,255),(0,0,0,255),
(0,0,0,255),(0,0,0,255),(0,0,0,255),(0,0,0,255),
(0,0,0,255),(0,0,0,255),(0,0,0,255),(0,0,0,255),
(0,0,0,255),(0,0,0,255),(0,0,0,255),(0,0,0,255)]

def drawPixelsWithPaletteOnImage(pixels, palette, im):
  if palette == emptyPalette:
    return False
  imArray = im.load()
  for i in range(len(pixels)):
    try: imArray[i%256,i/256] = palette[pixels[i]]
    except: e=0
  return True

def replaceTransparentWithBlack(im):
  imArray = im.load()
  for row in xrange(im.size[1]):
    for col in xrange(im.size[0]):
      p = imArray[col,row]
      if p[3] == 0: imArray[col,row] = (0,0,0,255)

def charsToInts(chars):
  result = [0] * len(chars)
  for i in range(len(chars)):
    result[i] = ord(chars[i])
  return result

def bytesToInt(bytes):
  result = 0
  result += bytes[0]
  result += bytes[1] * 256
  result += bytes[2] * 256 * 256
  result += bytes[3] * 256 * 256 * 256
  return result

def expandNibbles(bytes):
  result = [0] * len(bytes) * 2
  for i in range(len(bytes)):
    result[i*2] = upper(bytes[i])
    result[i*2+1] = lower(bytes[i])
  return result

def bytesToChars(bytes):
  chars = []
  for i in range(len(bytes)):
    chars.append(chr(bytes[i]))
  return ''.join(chars)

def copyRectangleToPoint(sourceImage, x, y, width, height, destImage, destX, destY, mirror, mirror2=0):
  def mir(pos,m): return m - pos - 1

  #print x,y,width,height
  sourceArray = sourceImage.load()
  destArray = destImage.load()
  if destX < 0 or destY < 0 or destX+width>destImage.size[0] or destY+height>destImage.size[1]:
    print destX, destY
  for row in xrange(height):
    for col in xrange(width):
      #print col,row
      p = sourceArray[x+col,y+row]
      if p[3] != 0:
        destArray[destX+(mir(col,width) if mirror else col),destY+(mir(row,height) if mirror2 else row)] = p

def splitImage(im):
  result = Image.new("RGBA", im.size, (0,0,0,0))
  #def copyRectangleToPoint(sourceImage, x, y, width, height, destImage, destX, destY, mirror):
  copyRectangleToPoint(im, 0, 0, 256, 256, result, 0, 0, False)
  copyRectangleToPoint(im, 0, 288, 256, 200, result, 0, 256, False)
  copyRectangleToPoint(im, 0, 256, 256, 32, result, 0, 456, False)

  if im.size[1] > 488:
    copyRectangleToPoint(im, 0, 488, 256, im.size[1]-488, result, 0, 488, False)
  result.save("split.png", "PNG")
  return result

def byteToBin(b):
  r=""
  for i in range(7,-1,-1):
    r += str((b&(1<<i)) >> i)
  return r

def logInfo(index, bytes):
  try:
    goods.index(index)
    hex=[]
    for b in bytes:
      hex.append("%02X" % (b))
    hex=" ".join(hex)
    print "%03d:" % (index),
    print hex,
    print " ",
    for b in bytes:
      print byteToBin(b),
    print "",
    fbin = byteToBin(bytes[3]) + byteToBin(bytes[2])
    print fbin[0:2] + " " + fbin[2:6] + " " + fbin[6:11] + " " + fbin[11:]
  except:
    return

goods=[52]
counter = -1

def getFrames(file, imageIn, wep=False):
  if wep:
    start = 0x802
  else:
    start = 0x402

  jump = bytesToInt(file[0:4])
  print 'jump',jump
  secondHalf = bytesToInt(file[4:6]+[0,0])
  thirdHalf = bytesToInt(file[6:8]+[0,0])
  frames=[]
  if jump > 8:
    frames.append(innerGetFrames(file[8:jump], imageIn, secondHalf, thirdHalf, start))
    frames.append(innerGetFrames(file[jump:], imageIn, secondHalf, thirdHalf, start, len(frames[0])))
  else:
    if wep:
      frames.append(innerGetFrames(file[0x44:], imageIn, secondHalf, thirdHalf, start))
    else:
      frames.append(innerGetFrames(file[8:], imageIn, secondHalf, thirdHalf, start))
  return frames


fToSize = { 0:(8,8),
1: (16,8), 2:(16,16), 3:(16,24), 
4:(24,8), 
#4:(24,24),
5:(24,16), 6:(24,24), 7:(32,8), 8:(32,16), 9:(32,24), 0xA:(32,32), 0xB:(32,40), 0xC:(48,16), 0xD:(40,32), 0xE:(48,48), 0xF:(56,56) }

def getOffsetBasedOnCount(count, second=0, mon=True):
  if mon:
    if count >= 0 and count <= 28: return 0
    elif count > 28 and count <= 57: return 256
    elif count > 57 and count <= 73: return 488
    elif count > 73 and count <= 154: return 256
    elif count > 154 and count <= 156: return 0
    elif count > 156 and count <= 170: return 256
    elif count > 170 and count <= 192: return 0
    else: return 256
  else:
    if count >= second:
      return 256
    else: return 0

def innerGetFrames(bytes, imageIn, secondHalf, thirdHalf, start, startingFrameNumber=0):
  numberOfFrames = 0x100
  global goods
  global counter
  result=[]
  print 'innerGetFrames %x' % len(bytes)
  for frameNumber in xrange(startingFrameNumber,numberOfFrames+startingFrameNumber):
    im = Image.new("RGBA", (185,250), (0,0,0,0))
    frameStart = start+bytesToInt(bytes[(frameNumber-startingFrameNumber)*0x04:(frameNumber-startingFrameNumber)*0x04+4])
    if frameStart==start and frameNumber != startingFrameNumber:
      break
    numberOfTile = bytesToInt(bytes[frameStart:frameStart+2] + [0,0])
    print 'processing frame %s at %x, %s tiles' % (frameNumber,frameStart,numberOfTile)
    if frameNumber == 131: print bytes[frameStart:frameStart+2+(numberOfTile+1)*4]
    rects = []
    for tileNumber in xrange(0,numberOfTile+1):
      counter += 1
      xbyte=bytes[frameStart+0x02+tileNumber*0x04]
      ybyte=bytes[frameStart+0x02+tileNumber*0x04+1];

      x=xbyte if ((xbyte & 0x80)==0) else (-(((xbyte)^0xff)+1))
      y=ybyte if ((ybyte & 0x80)==0) else (-(((ybyte)^0xff)+1))
      flags = bytesToInt(bytes[frameStart+0x02+tileNumber*4+2:frameStart+0x02+tileNumber*4+2+2] + [0,0])
      if frameNumber == 131:
        print '%d\t%d\t%d\t%04x' % (tileNumber,x,y,flags)
      mirror = flags & 0x4000
      mirror2 = flags & 0x8000
      f = (flags>>10) & 0xF
      
      if fToSize.has_key(f):
        (width, height) = fToSize[f]
      else:
        print "%d Unknown sprite value %04X" % (counter, (flags>>10)&0x0F)
        #continue
        width=4
        height=4
      tileX = (flags&0x001F) * 8
      tileY = ((flags>>5)&0x001F) * 8 + getOffsetBasedOnCount(frameNumber-startingFrameNumber, second=secondHalf, mon=False)
      goods.append(counter)


      rects.append((imageIn, tileX, tileY, width, height, im, x+53, y+118, mirror, mirror2))
    rects.reverse()
    for r in rects:
      copyRectangleToPoint(*r)
    result.append(im)
  return result

SP2={"ARLI.SPR":["ARLI2.SP2"],"BEHI.SPR":["BEHI2.SP2"],"BIBUROS.SPR":["BIBU2.SP2"],"BOM.SPR":["BOM2.SP2"],
"DEMON.SPR":["DEMON2.SP2"],"DORA2.SPR":["DORA22.SP2"],"HYOU.SPR":["HYOU2.SP2"],
"TETSU.SPR":["IRON2.SP2","IRON3.SP2","IRON4.SP2","IRON5.SP2"],
"MINOTA.SPR":["MINOTA2.SP2"],"MOL.SPR":["MOL2.SP2"],"TORI.SPR":["TORI2.SP2"],"URI.SPR":["URI2.SP2"]}

def convertFramesToPalette(frames, palette):
  result = []
  paletteSequence = []
  for p in palette: paletteSequence.extend(p[:3])
  for i in xrange(16,256): paletteSequence.extend([0,0,0])

  for i in xrange(len(frames)):
    im=Image.new("P", frames[i].size, 0)
    im.putpalette(paletteSequence)
    imArray = im.load()
    frameArray = frames[i].load()
    for x in xrange(frames[i].size[0]):
      for y in xrange(frames[i].size[1]):
        if frameArray[x,y][3] != 0:
          #print frameArray[x,y]
          #print palette
          imArray[x,y] = palette.index(frameArray[x,y])
    result.append(im)
  return result;

def processSequence(bytes,num,frames):
  #if num // 10 != 10: return
  #if num != 178: return
  bb=[]
  for b in bytes:
    bb.append("%02X"%b)
  print 'seq %s %s' % (num,bytes)
  sequence=[]
  i = 0
  wpos = 0
  while i < len(bytes) - 1:
    if bytes[i] != 0xFF:
      if bytes[i] < len(frames[0]):
        sequence[wpos:] = [(bytes[i], bytes[i+1])]
        #if bytes[i+1]: wpos += 1
        wpos += 1
    else:
      if bytes[i+1] in (192,198,211,212,214,215,216,226,238,239,240,246): i += 1
      elif bytes[i+1] in (193,217,242,252): i += 2
      elif bytes[i+1] in (250,): i += 3
    i += 2
  if not sequence: return
  for j in xrange(len(frames)):
    cmd = [r'ImageMagick-6.5.1-3\convert.exe','-dispose','Previous']
    for p in sequence:
      delay = p[1]
      if delay == 0xFF:
        print 'seq %s ff delay' % num
        delay = 30
      cmd.extend(['(','-delay','%dx60' % delay,getOutFilename(j,p[0]),')'])
    cmd.append('ani%x-%03d.gif' % (j,num))
    check_call(cmd)

def readSequence(bytes, frames, palette):
  offsets=[]
  for i in xrange(0x100):
    n=bytesToInt(bytes[4+i*4:4+i*4+4])
    if n==0xFFFF:
      break
    else:
      offsets.append(n)
  animationStart = 0x406
  for i in xrange(len(offsets)-1):
    processSequence(bytes[animationStart+offsets[i]:animationStart+offsets[i+1]], i,frames)
  processSequence(bytes[animationStart+offsets[-1]:], len(offsets)-1,frames)

def main(argv=None):
  if argv is None:
    argv = sys.argv
  fn = argv[1]
  print fn
  print argv[2]
  data = open(fn,'rb').read()

  compress_start = 0x9200
  if fn == "KASANEK.SPR" or fn == "KASANEM.SPR":
    compress_start = 0x8200

  h=0
  decompressed = []
  if len(data) >= compress_start and ord(data[compress_start]) != 0:
    decompressed = SprDec(data[compress_start:])
    h = 488  
  else:
    h = 288

  others=""
  if SP2.has_key(os.path.split(fn)[-1]):
    for sp2 in SP2[os.path.split(fn)[-1]]:
      others += open(os.path.join(os.path.split(fn)[0],sp2),'rb').read()
      h += 256

  bytes=data[16*32:compress_start]

  pixels = buildPixels(bytes)
  for i in range(len(decompressed)):
    pixels.append(decompressed[i])

  otherPixels = buildPixels(others)
  for i in range(len(otherPixels)):
    pixels.append(otherPixels[i])

  size=(256,max(488,h))

  im = Image.new("RGBA", size, (0,0,0,0))
  drawPixelsWithPaletteOnImage(pixels, buildPalette(data[0:32]), im)

  im2=splitImage(im)
  shp=charsToInts(open(argv[2],'rb').read())
  print 'shp file %x bytes' % len(shp)

  im3=im2.copy()
  replaceTransparentWithBlack(im3)
  im3.save("dongs.png", "PNG")

  frames=getFrames(shp, im2)

  for j in xrange(len(frames)):
    for i in xrange(len(frames[j])):
      frames[j][i].save(getOutFilename(j,i), "png")

  print "dongs"
  if len(argv)>3:
    seq=charsToInts(open(argv[3],'rb').read())
    readSequence(seq, frames, buildPalette(data[0:32]))

if __name__ == "__main__":
  sys.exit(main())
