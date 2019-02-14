using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace AutoCompleteComboBox
{
    public class SuggestComboBox : ComboBox
    {
        #region fields and properties

        private readonly ListBox suggestionListBox = new ListBox { Visible = false, TabStop = false };
        private readonly BindingList<string> suggBindingList = new BindingList<string>();

        private Expression<Func<ObjectCollection, IEnumerable<string>>> propertySelector;
        private Func<ObjectCollection, IEnumerable<string>> propertySelectorCompiled;
        private Expression<Func<string, string, bool>> filterRule;
        private Func<string, bool> filterRuleCompiled;
        private Expression<Func<string, string>> suggestListOrderRule;
        private Func<string, string> suggestListOrderRuleCompiled;

        public int SuggestBoxHeight
        {
            get => suggestionListBox.Height;
            set { if (value > 0) suggestionListBox.Height = value; }
        }

        /// <summary>
        /// If the item-type of the ComboBox is not string,
        /// you can set here which property should be used
        /// </summary>
        public Expression<Func<ObjectCollection, IEnumerable<string>>> PropertySelector
        {
            get => propertySelector;
            set
            {
                if (value == null) return;
                propertySelector = value;
                propertySelectorCompiled = value.Compile();
            }
        }

        ///<summary>
        /// Lambda-Expression to determine the suggested items
        /// (as Expression here because simple lamda (func) is not serializable)
        /// <para>default: case-insensitive contains search</para>
        /// <para>1st string: list item</para>
        /// <para>2nd string: typed text</para>
        ///</summary>
        public Expression<Func<string, string, bool>> FilterRule
        {
            get => filterRule;
            set
            {
                if (value == null) return;
                filterRule = value;
                filterRuleCompiled = item => value.Compile()(item, Text);
            }
        }

        ///<summary>
        /// Lambda-Expression to order the suggested items
        /// (as Expression here because simple lamda (func) is not serializable)
        /// <para>default: alphabetic ordering</para>
        ///</summary>
        public Expression<Func<string, string>> SuggestListOrderRule
        {
            get => suggestListOrderRule;
            set
            {
                if (value == null) return;
                suggestListOrderRule = value;
                suggestListOrderRuleCompiled = value.Compile();
            }
        }

        #endregion

        /// <summary>
        /// ctor
        /// </summary>
        public SuggestComboBox()
        {
            filterRuleCompiled = s => s.ToLower().Contains(Text.Trim().ToLower());
            suggestListOrderRuleCompiled = s => s;
            propertySelectorCompiled = collection => collection.Cast<string>();

            suggestionListBox.DataSource = suggBindingList;
            suggestionListBox.Click += SuggestionListBoxOnClick;

            ParentChanged += OnParentChanged;
        }

        /// <summary>
        /// the magic happens here ;-)
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            if (!Focused) return;

            suggBindingList.Clear();
            suggBindingList.RaiseListChangedEvents = false;
            propertySelectorCompiled(Items)
                 .Where(filterRuleCompiled)
                 .OrderBy(suggestListOrderRuleCompiled)
                 .ToList()
                 .ForEach(suggBindingList.Add);
            suggBindingList.RaiseListChangedEvents = true;
            suggBindingList.ResetBindings();

            if (suggestionListBox.Visible = suggBindingList.Any())
            {
                suggestionListBox.BringToFront();
            }

            if (suggBindingList.Count == 1 &&
                        suggBindingList.Single().Length == Text.Trim().Length)
            {
                Text = suggBindingList.Single();
                Select(0, Text.Length);
                suggestionListBox.Visible = false;
            }
        }

        #region size and position of suggest box

        /// <summary>
        /// suggest-ListBox is added to parent control
        /// (in ctor parent isn't already assigned)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnParentChanged(object sender, EventArgs e)
        {
            if (Parent != null)
            {
                Parent.Controls.Add(suggestionListBox);
                Parent.Controls.SetChildIndex(suggestionListBox, 0);
                suggestionListBox.Top = Top + Height;
                suggestionListBox.Left = Left;
                suggestionListBox.Width = Width;
                suggestionListBox.Font = Font;
            }
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            suggestionListBox.Top = Top + Height;
            suggestionListBox.Left = Left;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            suggestionListBox.Width = Width;
        }

        #endregion

        #region visibility of suggest box

        protected override void OnLostFocus(EventArgs e)
        {
            if (!suggestionListBox.Focused)
                HideSuggBox();
            base.OnLostFocus(e);
        }

        private void SuggestionListBoxOnClick(object sender, EventArgs eventArgs)
        {
            Text = suggestionListBox.Text;
            Focus();
        }

        private void HideSuggBox()
        {
            suggestionListBox.Visible = false;
        }

        protected override void OnDropDown(EventArgs e)
        {
            HideSuggBox();
            base.OnDropDown(e);
        }

        #endregion

        #region keystroke events

        private bool ProcessKeyDown(Keys keyData)
        {
            if (suggestionListBox.Visible)
            {
                switch (keyData)
                {
                    case Keys.Down:
                        if (suggestionListBox.SelectedIndex < suggBindingList.Count - 1)
                            suggestionListBox.SelectedIndex++;
                        return true;
                    case Keys.Up:
                        if (suggestionListBox.SelectedIndex > 0)
                            suggestionListBox.SelectedIndex--;
                        return true;
                    case Keys.Enter:
                    case Keys.Tab:
                    case Keys.Right:
                        Text = suggestionListBox.Text;
                        Select(0, Text.Length);
                        suggestionListBox.Visible = false;
                        return true;
                    case Keys.Escape:
                        HideSuggBox();
                        return true;
                }
            }
            return false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (ProcessKeyDown(keyData))
                return true;

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion
    }
}