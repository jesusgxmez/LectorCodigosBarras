namespace LectorCodigosBarras.Services;

public class VozWindowsService
{
    public async Task<string> DictarAsync()
    {
#if WINDOWS
        try
        {
            var reconocedor = new Windows.Media.SpeechRecognition.SpeechRecognizer();
            
            await reconocedor.CompileConstraintsAsync();

            var resultadoEscucha = await reconocedor.RecognizeAsync();

            if (resultadoEscucha.Status == Windows.Media.SpeechRecognition.SpeechRecognitionResultStatus.Success)
            {
                return resultadoEscucha.Text;
            }
        }
        catch (Exception error)
        {
            System.Diagnostics.Debug.WriteLine("Error de Voz en Windows: " + error.Message);
        }
#endif
        return string.Empty;
    }
}