using Xamarin.Forms;
using System.Threading.Tasks;
using System.Threading;
using XamarinBackgrounding.Messages;

namespace XamarinBackgrounding
{
    public class TaskCounter
    {
        public async Task RunCounter(CancellationToken token)
        {
            await Task.Run(async () =>
            {

                for (long i = 0; i < long.MaxValue; i++)
                {
                    token.ThrowIfCancellationRequested();

                    await Task.Delay(250);
                    var message = new TickedMessage
                    {
                        Message = i.ToString()
                    };

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        MessagingCenter.Send(message, "TickedMessage");
                    });
                }
            }, token);
        }
    }
}