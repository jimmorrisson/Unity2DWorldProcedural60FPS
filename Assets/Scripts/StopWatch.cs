using System.Collections;
using System.Timers;
using System.Diagnostics;
using System.Collections.Generic;
public class StopWatch
{
    Stopwatch watch;
    public float ElapsedMilliseconds
    {
        get
        {
            return watch.ElapsedMilliseconds;
        }
    }

    private float startTime;

    public void Start()
    {
        watch = Stopwatch.StartNew();
    }

    public void Reset()
    {
        watch.Reset();
    }

    public void Stop()
    {
        watch.Stop();
    }
}
