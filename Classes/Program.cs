using System;

namespace Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cittadino cittadino1 = new(true, 22, 90, 28, 0, 90M, true, true);
            Cittadino cittadino2 = new(true, 70, 100, 30, 5, 90M, true, false);

            Console.WriteLine(cittadino1.RdC());
            Console.WriteLine(cittadino2.RdC());

            Console.Read();
        }
    }

    public class Cittadino
    {
        Boolean _militare;
        int _età;
        int _mediaMaturità;
        int _mediaUniversitaria;
        int _figliACarico;
        decimal _PilComuneResidenza;
        Boolean _debiti;
        Boolean _studenteUniversitario;


        public Cittadino(Boolean militare, int età, int mediaMaturità,
        int mediaUniversitaria,
        int figliACarico,
        decimal PilComuneResidenza,
        Boolean debiti, bool studenteUniversitario)
        {
            _militare = militare;
            _età = età;
            _mediaMaturità = mediaMaturità;
            _mediaUniversitaria = mediaUniversitaria;
            _figliACarico = figliACarico;
            _PilComuneResidenza = PilComuneResidenza;
            _debiti = debiti;
            _studenteUniversitario = studenteUniversitario;
        }
        public string ToString()
        {
            return $"Militare: {_militare}, Età: {_età}, Media Maturità: {_mediaMaturità}, Media Universitaria: {_mediaUniversitaria}, Figli a Carico: {_figliACarico}, PIL Comune di Residenza: {_PilComuneResidenza}, Debiti: {_debiti}";
        }

        public string RdC()
        {
            int punteggio = 0;
            string idoneo = "";

            if (_militare == true) { punteggio += 2; }
            else
            { punteggio += 0; }
            if (_età >= 18 && _studenteUniversitario == true || _età <= 25 && _studenteUniversitario == true || _età > 60) { punteggio += 4; }
            else
            { punteggio += 0; }
            if (_mediaMaturità > 90) { punteggio += 5; }
            else
            { punteggio += 0; }
            if (_mediaUniversitaria > 28) { punteggio += 5; }
            else
            { punteggio += 0; }
            if (_figliACarico > 1) { punteggio += 3; }
            else
            { punteggio += 0; }
            if (_PilComuneResidenza < 100M) { punteggio += 7; }
            else
            { punteggio += 0; }
            if (_debiti == true) { punteggio += 10; }
            { punteggio += 0; }
            if (punteggio > 25) { idoneo = $"Il punteggio è {punteggio} dunque il cittadino è idoneo per il reddito di cittadinanza"; } else { idoneo = $"Il punteggio è {punteggio} dunque il cittadino non è idoneo per il reddito di cittadinanza"; }
            return idoneo;

        }

    }

}







