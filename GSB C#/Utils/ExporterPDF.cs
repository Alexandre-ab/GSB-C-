using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using iTextSharp.text; // Nécessite iTextSharp
using iTextSharp.text.pdf;
using GSB_C_.Models; // Pour accéder à ta classe Prescription
namespace GSB_C_.Utils
{
    public class ExporterPDF
    {// Cette méthode est spécifique pour les PRESCRIPTIONS

       private int PatientID;
      
        public bool ExporterPrescription(Prescription p, string cheminFichier)
        {
            try
            {
                // 1. Initialisation du document
                Document doc = new Document(PageSize.A4);
                PdfWriter.GetInstance(doc, new FileStream(cheminFichier, FileMode.Create));
                doc.Open();

                // 2. Mise en forme (C'est ici que tu personnalises le design)

                // -- Titre --
                var fontTitre = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24, BaseColor.BLUE);
                Paragraph titre = new Paragraph("ORDONNANCE GSB", fontTitre);
                titre.Alignment = Element.ALIGN_CENTER;
                titre.SpacingAfter = 30;
                doc.Add(titre);

                // -- Infos --
                var fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                var fontGras = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                    
                doc.Add(new Paragraph($"Date de l'ordonnance : {DateTime.Now.ToShortDateString()}", fontNormal));
                doc.Add(new Paragraph("\n")); // Saut de ligne
                 
                // On peut utiliser des "Chunk" pour mixer gras et normal
                Paragraph pPatient = new Paragraph();
                pPatient.Add(new Chunk("ID Patient : ", fontGras));
                pPatient.Add(new Chunk(PatientID.ToString(), fontNormal));
                doc.Add(pPatient);

                doc.Add(new Paragraph("-------------------------------------------------------------------\n"));

                // -- Contenu --
                doc.Add(new Paragraph("Médicament(s) prescrit(s) :", fontGras));
                doc.Add(new Paragraph($"Quantité : {p.Quantity} boîtes", fontNormal));

                // -- Validité --
                Paragraph pValidite = new Paragraph($"\nValidité jusqu'au : {p.Validity.ToShortDateString()}", fontGras);
                pValidite.Alignment = Element.ALIGN_RIGHT;
                doc.Add(pValidite);

                // 3. Fermeture
                doc.Close();
                return true;// Tout s'est bien passé
            }
            catch (Exception ex)
            {
                // En cas d'erreur (ex: fichier ouvert ailleurs), on retourne faux ou on log l'erreur
                Console.WriteLine("Erreur PDF : " + ex.Message);
                return false;
            }
        }

        // Si tu veux une méthode pour N'IMPORTE QUEL PDF simple (Titre + Contenu)
        public bool ExporterDocumentGenerique(string titre, string contenu, string cheminFichier)
        {
            try
            {
                Document doc = new Document(PageSize.A4);
                PdfWriter.GetInstance(doc, new FileStream(cheminFichier, FileMode.Create));
                doc.Open();

                doc.Add(new Paragraph(titre, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20)));
                doc.Add(new Paragraph("\n\n"));
                doc.Add(new Paragraph(contenu));

                doc.Close();
                return true;
            }
            catch { return false; }
        }
    }
}

