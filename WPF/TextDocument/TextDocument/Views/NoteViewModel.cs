using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace TextDocument.Views;

public partial class NoteViewModel : INotifyPropertyChanged
{
    private void Save()
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

        if (saveFileDialog.ShowDialog() == true)
        {
            string filePath = saveFileDialog.FileName;

            try
            {
                using (StreamWriter write = new StreamWriter(filePath))
                {
                    write.WriteLine(Note);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}");
            }

        }
    }

    private void SaveTo()
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

        if (saveFileDialog.ShowDialog() == true)
        {
            string filePath = saveFileDialog.FileName;

            try
            {
                using (StreamWriter write = new StreamWriter(filePath))
                {
                    write.WriteLine(Note);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}");
            }
        }
    }

    private void Open()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

        if (openFileDialog.ShowDialog() == true)
        {
            string filePath = openFileDialog.FileName;


            try
            {
                Note = File.ReadAllText(filePath, Encoding.Default);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии файла: {ex.Message}");
            }
        }
    }

    public void Cut()
    {
        _cutBuffer = Note;
        Note = string.Empty;
    }

    public void Copy()
    {
        _copyBuffer = Note;
    }

    public void Paste()
    {

        if (!string.IsNullOrEmpty(_copyBuffer))
        {
            Note += _copyBuffer;
        }
    }

    public void Delete()
    {
        Note = string.Empty;
    }

    public void Exit()
    {
        App.Current.Shutdown();
    }


}
