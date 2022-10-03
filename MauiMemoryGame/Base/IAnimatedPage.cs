using System;
namespace MauiMemoryGame.Base;

public interface IAnimatedPage
{
	Task RunAppearingAnimationAsync();
    Task RunDisappearingAnimationAsync();
}

