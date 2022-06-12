
using AsteriodeWEB.Models;
using Newtonsoft.Json;
using RestSharp.Contrib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AsteriodeWEB.WebRest
{
    public class NasaWeb
    {
        public List<Asteroide> GetRest(string url)
        {
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(url);
            myWebRequest.Credentials = CredentialCache.DefaultCredentials;
            myWebRequest.Proxy = null;

            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
            Stream myStream = myHttpWebResponse.GetResponseStream();
            StreamReader streamReader = new StreamReader(myStream);

            string datos = HttpUtility.HtmlDecode(streamReader.ReadToEnd());
            RootAsteriode root = JsonConvert.DeserializeObject<RootAsteriode>(datos);
            List<Asteroide> dataList = convertNasaToAsteriode(root);

            return dataList;
        }

        public List<Asteroide> convertNasaToAsteriode(RootAsteriode feed)
        {
            List<Asteroide> list = new List<Asteroide>();
            foreach (var asteroide in feed.near_earth_objects)
            {
                
                foreach(NasaAsteroide nasaAst in asteroide.Value)
                {
                    if (nasaAst.is_potentially_hazardous_asteroid) {
                        Asteroide ast = new Asteroide();
                        ast.Nombre = nasaAst.name;
                        ast.Diametro = (nasaAst.estimated_diameter.kilometers.estimated_diameter_max + nasaAst.estimated_diameter.kilometers.estimated_diameter_min)/2;
                        ast.Velocidad = nasaAst.close_approach_data.First().relative_velocity.kilometers_per_hour;
                        ast.Fecha = nasaAst.close_approach_data.First().close_approach_date;
                        ast.Planeta = nasaAst.close_approach_data.First().orbiting_body;
                        list.Add(ast);
                     }


                }
            }
            return list;
        }
    }
}
