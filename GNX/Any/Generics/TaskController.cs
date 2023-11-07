using System;
using System.Threading;
using System.Threading.Tasks;

namespace GNX
{
    public class TaskController
    {
        CancellationTokenSource Source;
        public bool IsCanceled;

        public TaskController()
        {
            Reset();
        }

        public void Reset()
        {
            Source = new CancellationTokenSource();
            IsCanceled = false;
        }

        public void Cancel()
        {
            Source.Cancel();
        }

        public async Task DelayStart(int secondsDelay)
        {
            try
            {
                await Task.Delay(secondsDelay * 1000, Source.Token);
            }
            catch (Exception)
            {
                IsCanceled = Source.IsCancellationRequested;
                return;
            }
        }

        public static async Task Delay(int secondsDelay)
        {
            await Task.Delay(secondsDelay * 1000);
        }
    }

    public static class TaskExtension
    {
#pragma warning disable
        // Asynchronous methods should return a Task instead of void
        public static async void AwaitSafe(this Task task)
#pragma warning restore
        {
            try
            {
                await task;
            }
            catch (Exception ex)
            {
                //var codeLine = ex.StackTrace.Split(Environment.NewLine.ToCharArray()).First().Split('\\').Last();
                //codeLine += Environment.NewLine + Environment.NewLine;
                var codeLine = ObjectManager.GetStackTrace();
                System.Windows.Forms.MessageBox.Show(codeLine + Environment.NewLine + "Task Failed: " + ex.Message);
            }
        }

        public static void RunIgnoreException(this Task task)
        {
            task.ContinueWith(_ => { return; });
        }
    }
}