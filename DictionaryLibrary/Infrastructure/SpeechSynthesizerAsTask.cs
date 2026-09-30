using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DictionaryLibrary.Infrastructure
{
    public class SpeechSynthesizerAsTask
    {
        SpeechSynthesizer synthesizer;
        Prompt results = null;
        TaskCompletionSource<Prompt> tcs;
        public SpeechSynthesizerAsTask()
        {
            synthesizer = new SpeechSynthesizer();
            EventHandler<SpeakCompletedEventArgs> del = (obj, args) =>
            {
                if (args.Cancelled)
                    tcs.SetCanceled();
                else if (args.Error != null)
                    tcs.SetException(args.Error);
                else 
                    tcs.TrySetResult(results);
            };
            synthesizer.SpeakCompleted += del;
        }

        public Task<Prompt> SpeakAsync(object speech, CancellationToken token)
        {
            tcs = new TaskCompletionSource<Prompt>(TaskCreationOptions.AttachedToParent);
 
            token.Register(() =>
            {
                synthesizer.SpeakAsyncCancel(results);
            });


            EventHandler<SpeakCompletedEventArgs> del = (obj, args) =>
                {
                    if (args.Cancelled)
                        tcs.TrySetResult(results);      //tcs.SetCanceled();
                    else if (args.Error != null)
                        tcs.SetException(args.Error);
                    else
                        tcs.TrySetResult(results);
                };
            synthesizer.SpeakCompleted += del;

            if (speech is string)
            {
                string speechAsSstring = speech as string;
                if (speechAsSstring.Contains("<speak"))
                    results = synthesizer.SpeakSsmlAsync(speechAsSstring);
                else
                    results = synthesizer.SpeakAsync(speechAsSstring);
            }
            else
            {
                results = (Prompt)speech;
                synthesizer.SpeakAsync(results);
            }

            return tcs.Task;
        }

        
        public SpeechSynthesizer Synthesizer
        {
            get { return synthesizer; }
        }
    }
}
