Module MProgress
    Sub hideProgress(ByVal p As ProgressBar)
        With p
            .Visible = False
            .MarqueeAnimationSpeed = 0
            .Style = ProgressBarStyle.Blocks
        End With
    End Sub

    Sub showProgress(ByVal p As ProgressBar)
        With p
            .Visible = True
            .MarqueeAnimationSpeed = 30
            .Style = ProgressBarStyle.Marquee
        End With
    End Sub

End Module
