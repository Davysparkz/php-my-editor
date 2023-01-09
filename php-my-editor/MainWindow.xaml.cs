using System;
using System.Drawing;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using php_my_editor.Utils;

namespace php_my_editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<int> _lineNumbers;
        private Dictionary<int, string> _editorContent;

        public MainWindow()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.pme.ToImageSource();
            this._lineNumbers = new List<int>();
            this._editorContent = new Dictionary<int, string>();
        }

        public void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        public void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("NEW COMMAND");
        }

        private void Editor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var row = editor.GetLineIndexFromCharacterIndex(editor.CaretIndex);
            var col = editor.CaretIndex - editor.GetCharacterIndexFromLineIndex(row);

            var lineText = editor.GetLineText(row);
            var lineNumber = row + 1;
            var charNumber = col;

            cursorPosLabel.Text = $"Line {lineNumber} , Char {charNumber}";

            if (!_lineNumbers.Contains(lineNumber))
            {
                _lineNumbers.Add(lineNumber);
                _editorContent.Add(lineNumber, lineText);
            }
            lineNumbers.Text = _lineNumbers.ToNewLinesString();
        }

        private void Editor_KeyDown(object sender, KeyEventArgs e)
        {
            var row = editor.GetLineIndexFromCharacterIndex(editor.CaretIndex);
            var lineText = editor.GetLineText(row);

            if (e.Key == Key.Back)
            {
                if (lineText.Length == 0)
                {
                    _lineNumbers.RemoveAt(_lineNumbers.Count);
                    lineNumbers.Text = _lineNumbers.ToNewLinesString();
                }
            }
        }
    }
}
