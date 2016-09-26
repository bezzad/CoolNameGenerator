using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CoolNameGenerator.Properties;

namespace CoolNameGenerator.Graphics
{
    public static class ControlsExtensions
    {
        public static IEnumerable<Control> GetControls(this Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>().ToArray();

            return controls.SelectMany(ctrl => GetControls(ctrl, type))
                .Concat(controls)
                .Where(c => c.GetType() == type);
        }

        public static IEnumerable<Control> GetControls(this Control control)
        {
            var controls = control.Controls.Cast<Control>().ToArray();

            return controls.SelectMany(GetControls).Concat(controls);
        }

        public static IEnumerable<ToolStripItem> GetToolStripItems(this MenuStrip menu)
        {
            var items = menu.Items.Cast<ToolStripMenuItem>().ToArray();

            return items.SelectMany(GetToolStripItems).Concat(items);
        }

        public static IEnumerable<ToolStripItem> GetToolStripItems(this ToolStripMenuItem mewnItem)
        {
            var items = new List<ToolStripItem>();

            foreach (var item in mewnItem.DropDownItems)
            {
                if (item.GetType() == typeof(ToolStripMenuItem))
                {
                    items.AddRange(GetToolStripItems(item as ToolStripMenuItem));
                }
                else // ToolStripItem
                {
                    items.Add(item as ToolStripItem);
                }
            }

            return items;
        }

        public static IEnumerable<ToolStripMenuItem> GetToolStripMenuItems(this MenuStrip menu)
        {
            var items = menu.Items.Cast<ToolStripMenuItem>().ToArray();

            return items.SelectMany(GetToolStripMenuItems).Concat(items);
        }

        public static IEnumerable<ToolStripMenuItem> GetToolStripMenuItems(this ToolStripMenuItem mewnItem)
        {
            var items = new List<ToolStripMenuItem>();

            foreach (var item in mewnItem.DropDownItems)
            {
                if (item.GetType() == typeof(ToolStripMenuItem))
                {
                    items.Add(item as ToolStripMenuItem);
                    items.AddRange(GetToolStripMenuItems(item as ToolStripMenuItem));
                }
            }

            return items;
        }

        public static void LocalizingMenuStrip(this MenuStrip menu)
        {
            var menuItems = GetToolStripMenuItems(menu);
            var items = GetToolStripItems(menu);

            foreach (var item in menuItems)
            {
                var replacmentText = Localization.ResourceManager.GetString(item.Text);
                if (!string.IsNullOrEmpty(replacmentText))
                {
                    item.Text = replacmentText;
                }
            }

            foreach (var item in items)
            {
                var replacmentText = Localization.ResourceManager.GetString(item.Text);
                if (!string.IsNullOrEmpty(replacmentText))
                {
                    item.Text = replacmentText;
                }
            }
        }

        public static void LocalizingGridColumns(this DataGridView dgv)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                var replacmentText = Localization.ResourceManager.GetString(col.HeaderText);
                if (!string.IsNullOrEmpty(replacmentText))
                {
                    col.HeaderText = replacmentText;
                }
            }
        }

        public static void LocalizingControl(this Control ctrl)
        {
            if (!string.IsNullOrEmpty(ctrl?.Text))
            {
                ctrl.Text = Localization.ResourceManager.GetString(ctrl.Text);
            }

            var controls = GetControls(ctrl);

            foreach (var c in controls)
            {
                if (c.GetType() == typeof(MenuStrip))
                {
                    LocalizingMenuStrip((MenuStrip) c);
                }
                else if (c.GetType() == typeof(DataGridView))
                {
                    LocalizingGridColumns((DataGridView) c);
                }
                else
                {
                    var replacmentText = Localization.ResourceManager.GetString(c.Text);
                    if (!string.IsNullOrEmpty(replacmentText))
                    {
                        c.Text = replacmentText;
                    }
                }
            }
        }
    }
}