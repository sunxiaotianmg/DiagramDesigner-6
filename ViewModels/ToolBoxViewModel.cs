﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using DiagramDesigner;
using Microsoft.Win32;
using System.IO;

namespace DiagramDesigner
{
    public class ToolBoxViewModel
    {
        private ObservableCollection<ToolBoxData> _blockDiagram = new ObservableCollection<ToolBoxData>();
        private ObservableCollection<ToolBoxData> _customElements = new ObservableCollection<ToolBoxData>();

        private const string Directory = "/Resources/Images/";
        public SimpleCommand AddItemCommand { get; private set; }

        public ToolBoxViewModel()
        {
            AddItemCommand = new SimpleCommand(ExecuteAddItemCommand);

            _blockDiagram.Add(new ToolBoxData(Directory + "Text.png", typeof(TextBoxDesignerItemViewModel), null));
            _blockDiagram.Add(new ToolBoxData(Directory + "Rectangle.png", typeof(RectangleDesignerItemViewModel), null));
            _blockDiagram.Add(new ToolBoxData(Directory + "Parallelo.png", typeof(ParallelogramDesignerItemViewModel), null));
            _blockDiagram.Add(new ToolBoxData(Directory + "roundedRec.png", typeof(RoundedRectangleDesignerItemViewModel), 20));
            _blockDiagram.Add(new ToolBoxData(Directory + "Ellipse.png", typeof(RoundedRectangleDesignerItemViewModel), 40));
            _blockDiagram.Add(new ToolBoxData(Directory + "Circle.png", typeof(RoundedRectangleDesignerItemViewModel), 9999));
            _blockDiagram.Add(new ToolBoxData(Directory + "Rhombus.png", typeof(UniversalDesignerItemViewModel), null));
            _blockDiagram.Add(new ToolBoxData(Directory + "cicleup.png", typeof(UniversalDesignerItemViewModel), null));
            _blockDiagram.Add(new ToolBoxData(Directory + "cicledown.png", typeof(UniversalDesignerItemViewModel), null));

        }
        private void ExecuteAddItemCommand(object parametr)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            openFileDialog.Title = "Выбор файла";
            string _filepath;
            string _filename;
            if (openFileDialog.ShowDialog() == true)
            {
                _filepath = openFileDialog.FileName;
                _filename = openFileDialog.SafeFileName;
                try
                {
                    //File.Copy(_filepath, Path.Combine("../../" + Directory, _filename), true);

                    System.IO.Directory.CreateDirectory("../../bin/Debug/Resources/Images/");
                    File.Copy(_filepath, Path.Combine("../../bin/Debug/Resources/Images/" + _filename), true);
                }
                catch { new Exception(); }
                _customElements.Add(new ToolBoxData("pack://siteoforigin:,,,/Resources/Images/" + _filename, typeof(UniversalDesignerItemViewModel),  null));
            }
        }
        public ObservableCollection<ToolBoxData> BlockDiagram
        {
            get { return _blockDiagram; }
        }
        public ObservableCollection<ToolBoxData> CustomElements
        {
            get { return _customElements; }
        }
    }
}
