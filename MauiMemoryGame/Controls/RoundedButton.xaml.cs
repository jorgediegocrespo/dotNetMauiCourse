﻿using System.Windows.Input;

namespace MauiMemoryGame.Controls;

public partial class RoundedButton
{
    public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(RoundedButton), propertyChanged: CommandChanged);
    public static readonly BindableProperty ButtonTypeProperty = BindableProperty.Create(nameof(ButtonType), typeof(RoundedButtonType), typeof(RoundedButton), defaultBindingMode: BindingMode.OneWay, defaultValue: RoundedButtonType.Back, propertyChanged: ButtonTypeChanged);
    public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(RoundedButton), defaultBindingMode: BindingMode.OneWay, propertyChanged: IsBusyChanged);

    public RoundedButton()
	{
		InitializeComponent();
        RefreshIcon();
	}

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public RoundedButtonType ButtonType
    {
        get => (RoundedButtonType)GetValue(ButtonTypeProperty);
        set => SetValue(ButtonTypeProperty, value);
    }

    public bool IsBusy
    {
        get => (bool)GetValue(IsBusyProperty);
        set => SetValue(IsBusyProperty, value);
    }

    private void RefreshIcon()
    {
        btCustomSource.Glyph = ButtonType switch
        {
            RoundedButtonType.Back => "\ue5c4",
            RoundedButtonType.Close => "\ue5cd",
            _ => throw new InvalidOperationException()
        };
    }

    private static void CommandChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((RoundedButton)bindable).btCustom.Command = (ICommand)newValue;
    }

    private static void ButtonTypeChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((RoundedButton)bindable).RefreshIcon();
    }

    private static void IsBusyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        RoundedButton control = (RoundedButton)bindable;
        bool value = (bool)newValue;

        control.btCustom.IsVisible = !value;
        control.aiBusy.IsRunning = value;
        control.aiBusy.IsVisible = value;
    }
}

public enum RoundedButtonType
{
    Back,
    Close
}
