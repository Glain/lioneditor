﻿/*
    Copyright 2007, Joe Davidson <joedavidson@gmail.com>

    This file is part of FFTPatcher.

    LionEditor is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    LionEditor is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with LionEditor.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Text;
using System.Windows.Forms;

namespace FFTPatcher.Editors
{
    public partial class CodeCreator : UserControl
    {
        public CodeCreator()
        {
            InitializeComponent();
        }

        protected override void OnVisibleChanged( EventArgs e )
        {
            StringBuilder sb = new StringBuilder();
            if( MainForm.AllAbilities != null )
            {
                sb.AppendLine( "_C0 Abilities" );
                sb.AppendLine( MainForm.AllAbilities.GenerateCodes() );
            }
            if( MainForm.AllJobs != null )
            {
                sb.AppendLine( "_C0 Jobs" );
                sb.AppendLine( MainForm.AllJobs.GenerateCodes() );
            }
            if( MainForm.AllSkillSets != null )
            {
                sb.AppendLine( "_C0 Skill Sets" );
                sb.AppendLine( MainForm.AllSkillSets.GenerateCodes() );
            }
            if( MainForm.AllMonsterSkills != null )
            {
                sb.AppendLine( "_C0 Monster Skill Sets" );
                sb.AppendLine( MainForm.AllMonsterSkills.GenerateCodes() );
            }
            if( MainForm.AllActionMenus != null )
            {
                sb.AppendLine( "_C0 Action Menus" );
                sb.AppendLine( MainForm.AllActionMenus.GenerateCodes() );
            }
            if( MainForm.AllStatusAttributes != null )
            {
                sb.AppendLine( "_C0 Status Effects" );
                sb.AppendLine( MainForm.AllStatusAttributes.GenerateCodes() );
            }
            if( MainForm.AllPoachProbabilities != null )
            {
                sb.AppendLine( "_C0 Poaching" );
                sb.AppendLine( MainForm.AllPoachProbabilities.GenerateCodes() );
            }
            if( MainForm.JobLevels != null )
            {
                sb.AppendLine( "_C0 Job Levels" );
                sb.AppendLine( MainForm.JobLevels.GenerateCodes() );
            }
            if( MainForm.AllItems != null )
            {
                sb.AppendLine( "_C0 Items" );
                sb.AppendLine( MainForm.AllItems.GenerateCodes() );
            }
            if( MainForm.AllItemAttributes != null )
            {
                sb.AppendLine( "_C0 Item Attributes" );
                sb.AppendLine( MainForm.AllItemAttributes.GenerateCodes() );
            }
            if( MainForm.AllInflictStatuses != null )
            {
                sb.AppendLine( "_C0 Inflict Statuses" );
                sb.AppendLine( MainForm.AllInflictStatuses.GenerateCodes() );
            }
            textBox1.Text = sb.ToString();
            base.OnVisibleChanged( e );
        }
    }
}
