using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Globalization;
using System.Runtime.InteropServices;

namespace reconocimiento_de_voz
{

    public partial class Form1 : Form
    {
        SpeechSynthesizer _synthesizer = new SpeechSynthesizer();
        //  SpeechRecognitionEngine _Recognition = new SpeechRecognitionEngine(new CultureInfo("es-VE"));
        SpeechRecognitionEngine _Recognition = new SpeechRecognitionEngine();
        public Form1()
        {

            InitializeComponent();

                _Recognition.SetInputToDefaultAudioDevice();
                _Recognition.LoadGrammar(new DictationGrammar());
                _Recognition.SpeechRecognized += _Recognition_SpeechRecognized;
                _Recognition.RecognizeAsync(RecognizeMode.Multiple);
         
        }

        private void _Recognition_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            RecognitionResult a = e.Result;
            texto.Text = a.Text;
            _synthesizer.SelectVoice("eSpeak-es");
            _synthesizer.SpeakAsync(texto.Text);
           
        }
    }
}
