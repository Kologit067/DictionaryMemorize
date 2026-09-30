using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using DictionaryMemorize.ViewModel;
using DictionaryLibrary.Common;

namespace DictionaryMemorize.View
{
    /// <summary>
    /// Interaction logic for DictionaryView.xaml
    /// </summary>
    //-------------------------------------------------------------------------------------------------------------------
    // class DictionaryView
    //-------------------------------------------------------------------------------------------------------------------
    public partial class DictionaryView : Window
    {
        //-------------------------------------------------------------------------------------------------------------------
        public DictionaryView()
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------------------------------------------------
        public static DependencyProperty MouseMoveCommandProperty = DependencyProperty.RegisterAttached(
                                                                        "MouseMoveCommand",
                                                                        typeof(ICommand),
                                                                        typeof(DictionaryView) );
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand MouseMoveCommand
        {
            get { return (ICommand)GetValue(MouseMoveCommandProperty); }
            set { SetValue(MouseMoveCommandProperty, value); }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public static void SetMouseMoveCommand(DependencyObject target, ICommand value)
        {
            target.SetValue(DictionaryViewAttachedBehaviour.MouseMoveCommandProperty, value);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public static ICommand GetMouseMoveCommand(DependencyObject target)
        {
            return (ICommand)target.GetValue(DictionaryViewAttachedBehaviour.MouseMoveCommandProperty);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public static DependencyProperty ErrorLevelValueDropCommandProperty = DependencyProperty.RegisterAttached(
                                                                        "ErrorLevelValueDropCommand",
                                                                        typeof(ICommand),
                                                                        typeof(DictionaryView));
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand ErrorLevelValueDropCommand
        {
            get { return (ICommand)GetValue(ErrorLevelValueDropCommandProperty); }
            set { SetValue(ErrorLevelValueDropCommandProperty, value); }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public static DependencyProperty ErrorLevelRelationDropCommandProperty = DependencyProperty.RegisterAttached(
                                                                        "ErrorLevelRelationDropCommand",
                                                                        typeof(ICommand),
                                                                        typeof(DictionaryView));
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand ErrorLevelRelationDropCommand
        {
            get { return (ICommand)GetValue(ErrorLevelRelationDropCommandProperty); }
            set { SetValue(ErrorLevelRelationDropCommandProperty, value); }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public static DependencyProperty ConsolidatedErrorLevelDropCommandProperty = DependencyProperty.RegisterAttached(
                                                                        "ConsolidatedErrorLevelDropCommand",
                                                                        typeof(ICommand),
                                                                        typeof(DictionaryView));
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand ConsolidatedErrorLevelDropCommand
        {
            get { return (ICommand)GetValue(ConsolidatedErrorLevelDropCommandProperty); }
            set { SetValue(ConsolidatedErrorLevelDropCommandProperty, value); }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public static DependencyProperty ConsolidatedErrorLevelRelationDropCommandProperty = DependencyProperty.RegisterAttached(
                                                                        "ConsolidatedErrorLevelRelationDropCommand",
                                                                        typeof(ICommand),
                                                                        typeof(DictionaryView));
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand ConsolidatedErrorLevelRelationDropCommand
        {
            get { return (ICommand)GetValue(ConsolidatedErrorLevelRelationDropCommandProperty); }
            set { SetValue(ConsolidatedErrorLevelRelationDropCommandProperty, value); }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void Window_Closed_1(object sender, EventArgs e)
        {
            DictionaryMemorize.Properties.Settings.Default.Save();
            ISavable viewModel = DataContext as ISavable;
            if (viewModel != null)
            {
                viewModel.Save();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            //UserView userView = new UserView(); // создали View
            //UserViewModel userViewModel = new UserViewModel(); // Создали ViewModel
            //userView.DataContext = userViewModel; // положили ViewModel во View в качестве DataContext
            //userView.ShowDialog();
            viewWords.SelectedIndex = 0;
            SetFocus();
            ISetFocusQueriable viewModel = DataContext as ISetFocusQueriable;
            if (viewModel != null)
            {
                viewModel.QuerySetFocus += SetFocus;
            }

            Binding myBinding = new Binding("WordStatisticDragDropCommand");
            myBinding.Source =  DataContext;
            BindingOperations.SetBinding(this, DictionaryView.MouseMoveCommandProperty, myBinding);

            Binding bindingErrorLevelValue = new Binding("ErrorLevelValueDropCommand");
            bindingErrorLevelValue.Source = DataContext;
            BindingOperations.SetBinding(this, DictionaryView.ErrorLevelValueDropCommandProperty, bindingErrorLevelValue);
            
            Binding bindingErrorLevelRelation = new Binding("ErrorLevelRelationDropCommand");
            bindingErrorLevelRelation.Source = DataContext;
            BindingOperations.SetBinding(this, DictionaryView.ErrorLevelRelationDropCommandProperty, bindingErrorLevelRelation);
            Binding bindingConsolidatedErrorLevel = new Binding("ConsolidatedErrorLevelDropCommand");
            bindingConsolidatedErrorLevel.Source = DataContext;
            BindingOperations.SetBinding(this, DictionaryView.ConsolidatedErrorLevelDropCommandProperty, bindingConsolidatedErrorLevel);
            Binding bindingConsolidatedErrorLevelRelation = new Binding("ConsolidatedErrorLevelRelationDropCommand");
            bindingConsolidatedErrorLevelRelation.Source = DataContext;
            BindingOperations.SetBinding(this, DictionaryView.ConsolidatedErrorLevelRelationDropCommandProperty, bindingConsolidatedErrorLevelRelation);
            IScrollIntoViewAction scrollIntoViewAction = (IScrollIntoViewAction)DataContext;
            if (scrollIntoViewAction != null)
            {
                scrollIntoViewAction.SpeechPhraseScrollIntoView += () =>
                {
                    SpeechPhraseScrollIntoView();
                };
            }

        }
        //-------------------------------------------------------------------------------------------------------------------
        private void SetFocus()
        {
            Keyboard.Focus(txtAnswer);
        }

        //-------------------------------------------------------------------------------------------------------------------
        private void dgWordStatistic_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && MouseMoveCommand != null)
                MouseMoveCommand.Execute(sender);
        }
        //-------------------------------------------------------------------------------------------------------------------

        private void txtErrorLevelValue_Drop_1(object sender, DragEventArgs e)
        {
            if (ErrorLevelValueDropCommand != null)
                ErrorLevelValueDropCommand.Execute(e.Data);
            e.Handled = true;
        }
        //-------------------------------------------------------------------------------------------------------------------

        private void txtErrorLevelRelation_Drop_1(object sender, DragEventArgs e)
        {
            if (ErrorLevelRelationDropCommand != null)
                ErrorLevelRelationDropCommand.Execute(e.Data);
            e.Handled = true;

        }
        //-------------------------------------------------------------------------------------------------------------------

        private void txtConsolidatedErrorLevelValue_Drop_1(object sender, DragEventArgs e)
        {
            if (ConsolidatedErrorLevelDropCommand != null)
                ConsolidatedErrorLevelDropCommand.Execute(e.Data);
            e.Handled = true;

        }
        //-------------------------------------------------------------------------------------------------------------------

        private void txtConsolidatedErrorLevelRelation_Drop_1(object sender, DragEventArgs e)
        {
            if (ConsolidatedErrorLevelRelationDropCommand != null)
                ConsolidatedErrorLevelRelationDropCommand.Execute(e.Data);
            e.Handled = true;

        }
        //-------------------------------------------------------------------------------------------------------------------
        private void SpeechPhraseScrollIntoView()
        {
            try
            {
                lbSpeechPhrase.ScrollIntoView(lbSpeechPhrase.SelectedItem);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
    // class VisibilityConverter
    //-------------------------------------------------------------------------------------------------------------------
    [ValueConversion(typeof(bool),typeof(Visibility))]
    public class VisibilityConverter : IValueConverter
    {
        //-------------------------------------------------------------------------------------------------------------------
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool visibility = (bool)value;
            if (visibility)
                return Visibility.Visible;
            return Visibility.Collapsed;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
    // class WorkOnMistakeRegimEnumForErrorLevelValueConverter
    //-------------------------------------------------------------------------------------------------------------------
    [ValueConversion(typeof(WorkOnMistakeRegimEnum), typeof(bool))]
    public class WorkOnMistakeRegimEnumForErrorLevelValueConverter : IValueConverter
    {
        //-------------------------------------------------------------------------------------------------------------------
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            WorkOnMistakeRegimEnum regimValue = (WorkOnMistakeRegimEnum)value;
            if (WorkOnMistakeRegimEnum.ErrorLevelValue == regimValue)
                return true;
            return false;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool boolValue = (bool)value;
            if (boolValue)
                return WorkOnMistakeRegimEnum.ErrorLevelValue;
            return null;
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
    // class WorkOnMistakeRegimEnumForErrorLevelRelationConverter
    //-------------------------------------------------------------------------------------------------------------------
    [ValueConversion(typeof(WorkOnMistakeRegimEnum), typeof(bool))]
    public class WorkOnMistakeRegimEnumForErrorLevelRelationConverter : IValueConverter
    {
        //-------------------------------------------------------------------------------------------------------------------
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            WorkOnMistakeRegimEnum regimValue = (WorkOnMistakeRegimEnum)value;
            if (WorkOnMistakeRegimEnum.ErrorLevelRelation == regimValue)
                return true;
            return false;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool boolValue = (bool)value;
            if (boolValue)
                return WorkOnMistakeRegimEnum.ErrorLevelRelation;
            return null;
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
    // class WorkOnMistakeRegimEnumForConsolidatedErrorLevelValueConverter
    //-------------------------------------------------------------------------------------------------------------------
    [ValueConversion(typeof(WorkOnMistakeRegimEnum), typeof(bool))]
    public class WorkOnMistakeRegimEnumForConsolidatedErrorLevelValueConverter : IValueConverter
    {
        //-------------------------------------------------------------------------------------------------------------------
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            WorkOnMistakeRegimEnum regimValue = (WorkOnMistakeRegimEnum)value;
            if (WorkOnMistakeRegimEnum.ConsolidatedErrorLevelValue == regimValue)
                return true;
            return false;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool boolValue = (bool)value;
            if (boolValue)
                return WorkOnMistakeRegimEnum.ConsolidatedErrorLevelValue;
            return null;
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
    //  
    //-------------------------------------------------------------------------------------------------------------------
    // class WorkOnMistakeRegimEnumForConsolidatedErrorLevelRelationConverter
    //-------------------------------------------------------------------------------------------------------------------
    [ValueConversion(typeof(WorkOnMistakeRegimEnum), typeof(bool))]
    public class WorkOnMistakeRegimEnumForConsolidatedErrorLevelRelationConverter : IValueConverter
    {
        //-------------------------------------------------------------------------------------------------------------------
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            WorkOnMistakeRegimEnum regimValue = (WorkOnMistakeRegimEnum)value;
            if (WorkOnMistakeRegimEnum.ConsolidatedErrorLevelRelation == regimValue)
                return true;
            return false;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool boolValue = (bool)value;
            if (boolValue)
                return WorkOnMistakeRegimEnum.ConsolidatedErrorLevelRelation;
            return null;
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
    public class DictionaryViewAttachedBehaviour
    {
        public static DependencyProperty MouseMoveCommandProperty = DependencyProperty.RegisterAttached(
                                                                        "MouseMoveCommand",
                                                                        typeof(ICommand),
                                                                        typeof(DictionaryViewAttachedBehaviour),
                                                                        new FrameworkPropertyMetadata( new PropertyChangedCallback(DictionaryViewAttachedBehaviour.MouseMoveChanged)));
        //-------------------------------------------------------------------------------------------------------------------
        public static void SetMouseMoveCommand(DependencyObject target, ICommand value)
        {
            target.SetValue(DictionaryViewAttachedBehaviour.MouseMoveCommandProperty, value);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public static ICommand GetMouseMoveCommand(DependencyObject target)
        {
            return (ICommand)target.GetValue(DictionaryViewAttachedBehaviour.MouseMoveCommandProperty);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private static void MouseMoveChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = target as UIElement;
            if (element != null)
            {
                // If we're putting in a new command and there wasn't one already
                // hook the event
                if ((e.NewValue != null) && (e.OldValue == null))
                {
                    element.MouseMove += element_MouseMove;
                }
                // If we're clearing the command and it wasn't already null
                // unhook the event
                else if ((e.NewValue == null) && (e.OldValue != null))
                {
                    element.MouseMove -= element_MouseMove;
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        static void element_MouseMove(object sender, MouseEventArgs e)
        {
            UIElement element = (UIElement)sender;
            ICommand command = (ICommand)element.GetValue(DictionaryViewAttachedBehaviour.MouseMoveCommandProperty);
            command.Execute(element.GetValue(DictionaryViewAttachedBehaviour.MouseMoveCommandProperty));
        }
        //-------------------------------------------------------------------------------------------------------------------
        public static DependencyProperty DropCommandProperty = DependencyProperty.RegisterAttached(
                                                                        "DropCommand",
                                                                        typeof(ICommand),
                                                                        typeof(DictionaryViewAttachedBehaviour),
                                                                        new FrameworkPropertyMetadata(new PropertyChangedCallback(DictionaryViewAttachedBehaviour.DropChanged)));
        //-------------------------------------------------------------------------------------------------------------------
        public static void SetDropCommand(DependencyObject target, ICommand value)
        {
            target.SetValue(DictionaryViewAttachedBehaviour.DropCommandProperty, value);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public static ICommand GetDropCommand(DependencyObject target)
        {
            return (ICommand)target.GetValue(DictionaryViewAttachedBehaviour.DropCommandProperty);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private static void DropChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = target as UIElement;
            if (element != null)
            {
                // If we're putting in a new command and there wasn't one already
                // hook the event
                if ((e.NewValue != null) && (e.OldValue == null))
                {
                    element.Drop += element_Drop;
                }
                // If we're clearing the command and it wasn't already null
                // unhook the event
                else if ((e.NewValue == null) && (e.OldValue != null))
                {
                    element.Drop -= element_Drop;
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        static void element_Drop(object sender, DragEventArgs e)
        {
            UIElement element = (UIElement)sender;
            ICommand command = (ICommand)element.GetValue(DictionaryViewAttachedBehaviour.DropCommandProperty);
            command.Execute(element.GetValue(DictionaryViewAttachedBehaviour.DropCommandProperty));
        }
        //-------------------------------------------------------------------------------------------------------------------
        public static DependencyProperty CommandParamProperty = DependencyProperty.RegisterAttached(
                                                                                "CommandParam",
                                                                                typeof(object),
                                                                                typeof(DictionaryViewAttachedBehaviour),
                                                                                new FrameworkPropertyMetadata(new PropertyChangedCallback(DictionaryViewAttachedBehaviour.CommandParamChanged)));
        //-------------------------------------------------------------------------------------------------------------------
        public static void SetCommandParam(DependencyObject target, object value)
        {
            target.SetValue(DictionaryViewAttachedBehaviour.CommandParamProperty, value);
        }
        //-------------------------------------------------------------------------------------------------------------------
        public static object GetCommandParam(DependencyObject target)
        {
            return (object)target.GetValue(DictionaryViewAttachedBehaviour.CommandParamProperty);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private static void CommandParamChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = target as UIElement;
            if (element != null)
            {
                // If we're putting in a new command and there wasn't one already
                // hook the event
                if ((e.NewValue != null) && (e.OldValue == null))
                {
                    element.SetValue(DictionaryViewAttachedBehaviour.CommandParamProperty, e.NewValue);
                }
                // If we're clearing the command and it wasn't already null
                // unhook the event
                else if ((e.NewValue == null) && (e.OldValue != null))
                {
                    element.SetValue(DictionaryViewAttachedBehaviour.CommandParamProperty, e.NewValue);
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
    }
    //-------------------------------------------------------------------------------------------------------------------
}
