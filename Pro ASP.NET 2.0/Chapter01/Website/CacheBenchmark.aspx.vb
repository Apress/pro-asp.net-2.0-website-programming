
Partial Class CacheBenchmark_aspx
    Inherits Page    

    '===============================================================================================
    Sub btnRunTest_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        '-----------------------------------------------------------------------
        'Timing Variables
        '-----------------------------------------------------------------------
        Dim StartTime As Date
        Dim EndTime As Date


        '-----------------------------------------------------------------------
        'Iteration Counters
        '-----------------------------------------------------------------------
        Dim NonCachedIterations As Long
        Dim NonCachedTotalSeconds As Long
        Dim NonCachedIterationsPerSecond As Long
        Dim CachedIterations As Long
        Dim CachedTotalSeconds As Long
        Dim CachedIterationsPerSecond As Long

        '-----------------------------------------------------------------------
        'Temporary Variable
        '-----------------------------------------------------------------------
        Dim Holder As Integer

        'Ensure valid entries for non-cached iterations
        If Not IsNumeric(Me.txtIterationsNonCached.Text) Then Me.txtIterationsNonCached.Text = "10000000"
        If CLng(Me.txtIterationsNonCached.Text) = 0 Then Me.txtIterationsNonCached.Text = "1"
        NonCachedIterations = CLng(Me.txtIterationsNonCached.Text)

        'Ensure valid entries for cached iterations
        If Not IsNumeric(Me.txtIterationsCached.Text) Then Me.txtIterationsCached.Text = "10000000"
        If CLng(Me.txtIterationsCached.Text) = 0 Then Me.txtIterationsCached.Text = "1"
        CachedIterations = CLng(Me.txtIterationsCached.Text)

        '-----------------------------------------------------------------------
        'Acquire Non-Cached Time
        '-----------------------------------------------------------------------
        StartTime = Now
        For Index As Long = 1 To NonCachedIterations            
            Holder = Config.MyIntegerWithNoCaching()
            Holder = 0
        Next
        EndTime = Now
        NonCachedTotalSeconds = DateDiff(DateInterval.Second, StartTime, EndTime)
        If NonCachedTotalSeconds = 0 Then NonCachedTotalSeconds += 1
        NonCachedIterationsPerSecond = CLng(NonCachedIterations / NonCachedTotalSeconds)
        Me.lblNonCached.Text = FormatNumber(NonCachedTotalSeconds, 0, TriState.True, TriState.False, TriState.True) & " seconds total."
        Me.lblNonCachedPerSecond.Text = FormatNumber(NonCachedIterationsPerSecond, 0, TriState.True, TriState.False, TriState.True) & " iterations per second"

        '-----------------------------------------------------------------------
        'Acquire Cached Time
        '-----------------------------------------------------------------------
        StartTime = Now
        For Index As Long = 1 To CachedIterations
            Holder = Config.MyInteger()
            Holder = 0
        Next
        EndTime = Now
        CachedTotalSeconds = DateDiff(DateInterval.Second, StartTime, EndTime)
        If CachedTotalSeconds = 0 Then CachedTotalSeconds += 1
        CachedIterationsPerSecond = CLng(CachedIterations / CachedTotalSeconds)
        Me.lblCached.Text = FormatNumber(CachedTotalSeconds, 0, TriState.True, TriState.False, TriState.True) & " seconds total."
        Me.lblCachedPerSecond.Text = FormatNumber(CachedIterationsPerSecond, 0, TriState.True, TriState.False, TriState.True) & " iterations per second"

        '-----------------------------------------------------------------------
        'Determine Difference
        '-----------------------------------------------------------------------
        Me.lblDifference.Text = "Caching is " & FormatNumber((((CachedIterationsPerSecond - NonCachedIterationsPerSecond) / NonCachedIterationsPerSecond) * 100), 2, TriState.True, TriState.False, TriState.True) & "% faster."

        '-----------------------------------------------------------------------
        'Show results in the panel
        '-----------------------------------------------------------------------
        Me.pnlResults.Visible = True

    End Sub

End Class
