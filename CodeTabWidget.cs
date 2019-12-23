﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Gtk;
using GtkSourceView;

namespace iCode
{
    [ToolboxItem(true)]
    public class CodeTabWidget : SourceView
    {
        private string s;
        private string file;
        private string actualText;

        private List<Gdk.Key> keys;

        private NotebookTabLabel notebookTabLabel;

        public CodeTabWidget(string file)
        {

            keys = new List<Gdk.Key>();
            base.Buffer = new SourceBuffer(new SourceLanguageManager().GetLanguage("objc"));
            notebookTabLabel = new NotebookTabLabel(System.IO.Path.GetFileName(file), this);
            this.file = file;
            actualText = File.ReadAllText(file);
            Buffer.Text = actualText;
            this.KeyPressEvent += Handle_KeyPressEvent;
            this.KeyReleaseEvent += Handle_KeyReleaseEvent;
            base.AutoIndent = true;
            base.ShowLineMarks = true;
            base.ShowLineNumbers = true;
            base.HighlightCurrentLine = false;
            base.IndentOnTab = true;
            this.s = base.Buffer.Text;
            base.Buffer.Changed += this.Buffer_Changed;
        }

        private void Buffer_Changed(object sender, EventArgs e)
        {
            #region CODE SAVING
            if (actualText != Buffer.Text)
            {
                if (!notebookTabLabel.Label.Text.EndsWith("*", StringComparison.CurrentCulture))
                {
                    notebookTabLabel.Label.Text += "*";
                }
            }
            else
            {
                if (notebookTabLabel.Label.Text.EndsWith("*", StringComparison.CurrentCulture))
                {
                    notebookTabLabel.Label.Text = notebookTabLabel.Label.Text.TrimEnd('*');
                }
            }
            #endregion

            if (e == null)
                return;

            #region CODE COMPLETION
            int cursorPosition = base.Buffer.CursorPosition;
            bool flag = this.s.Length == base.Buffer.Text.Length - 1;
            if (flag)
            {
                char c = base.Buffer.Text[cursorPosition - 1];
                char c2 = c;
                char c3 = c2;

                if (c3 != '\n')
                {
                    if (c3 == '{')
                    {
                        this.SetText(base.Buffer.Text.Insert(cursorPosition, "}"));
                        base.Buffer.PlaceCursor(base.Buffer.GetIterAtOffset(cursorPosition));
                    }
                }
                else
                {
                    try
                    {
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Code Completion failed: {0}", new object[]
                        {
                            ex
                        });
                    }
                }
            }
            else
            {
                bool flag2 = this.s.Length == base.Buffer.Text.Length + 1;
                if (flag2)
                {
                    char c4 = this.s[base.Buffer.CursorPosition];
                    Console.WriteLine("Removed {0}", new object[]
                    {
                        c4
                    });
                    int num = cursorPosition;
                    bool flag3 = c4 == '\t';
                    if (flag3)
                    {
                        string text = base.Buffer.Text;
                        while (text[num - 1] == '\t')
                        {
                            Console.WriteLine("At cursor there is {0}, before {1}, and after {2}", new object[]
                            {
                                this.s[num],
                                this.s[num - 1],
                                this.s[num + 1]
                            });
                            text = text.Remove(num - 1, 1);
                            num--;
                        }
                        bool flag4 = text[num - 1] == '\n';
                        if (flag4)
                        {
                            Console.WriteLine("At cursor there is {0}, before {1}, and after {2}", new object[]
                            {
                                this.s[num],
                                this.s[num - 1],
                                this.s[num + 1]
                            });
                            text = text.Remove(num - 1, 1);
                            num--;
                        }
                        this.SetText(text);
                        base.Buffer.PlaceCursor(base.Buffer.GetIterAtOffset(num));
                    }
                }
            }
            this.s = base.Buffer.Text;
            #endregion
        }

        void Handle_KeyPressEvent(object o, KeyPressEventArgs args)
        {
            Console.WriteLine(args.Event.Key + " pressed");
            keys.Add(args.Event.Key);

            if ((keys.Contains(Gdk.Key.s) || keys.Contains(Gdk.Key.S)) && (keys.Contains(Gdk.Key.Control_L) || keys.Contains(Gdk.Key.Control_R)))
            {
                SaveFile();
            }
        }

        void Handle_KeyReleaseEvent(object o, KeyReleaseEventArgs args)
        {
            Console.WriteLine(args.Event.Key + " released");
            keys.Remove(args.Event.Key);
        }

        public void SaveFile()
        {
            File.WriteAllText(file, Buffer.Text);
            actualText = Buffer.Text;
            Buffer_Changed(null, null);
        }

        public void SetText(string text)
        {
            Application.Invoke((a, b) =>
            {
                this.Buffer.Text = text;
            });
        }

        public NotebookTabLabel GetLabel()
        {
            return notebookTabLabel;
        }
    }
}
