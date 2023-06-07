using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TestWahyuInSanata.Models;

namespace TestWahyuInSanata.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProcessData(TestClass voData)
        {

            Dictionary<string, string> vsLogMessage = new Dictionary<string, string>();
            try
            {
                // Menghitung jumlah orang yang dibunuh pada tahun kelahiran masing-masing orang
                int killedA = CalculateKilled(voData.TahunA - voData.UmurA);
                int killedB = CalculateKilled(voData.TahunB - voData.UmurB);

                // Menghitung rata-rata jumlah orang yang dibunuh
                double average = (killedA + killedB) / 2.0;

                // Menampilkan hasil rata-rata
                vsLogMessage.Add("data", average.ToString());
                vsLogMessage.Add("killedA", killedA.ToString());
                vsLogMessage.Add("killedB", killedB.ToString());
                vsLogMessage.Add("errorcode", "0");
                vsLogMessage.Add("title", "Sukses");
                vsLogMessage.Add("msg", "Berhasil");
            }
            catch (Exception exc)
            {
                vsLogMessage.Add("errorcode", "500");
                vsLogMessage.Add("title", "Error");
                vsLogMessage.Add("msg", exc.Message);
            }
            return Json(vsLogMessage, JsonRequestBehavior.DenyGet);
        }

        static int CalculateKilled(int birthYear)
        {
            // Memvalidasi tahun kelahiran yang valid
            if (birthYear < 0)
            {
                return -1; // Jika tidak valid, mengembalikan -1
            }

            // Menghitung jumlah orang yang dibunuh pada tahun kelahiran
            int killed = 0;
            int previous = 0;
            int current = 1;

            for (int year = 1; year <= birthYear; year++)
            {
                killed += current;
                int temp = current;
                current += previous;
                previous = temp;
            }

            return killed;
        }

    }
}