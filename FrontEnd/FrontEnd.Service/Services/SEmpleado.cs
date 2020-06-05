using FrontEnd.Service.Entidades;
using FrontEnd.Service.Interfaces;
using FrontEnd.Util.Utils;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.Service.Services
{
    public class SEmpleado : IEmpleado
    {
        private readonly IOptions<ApiService> options;

        public SEmpleado(IOptions<ApiService> options)
        {
            this.options = options;
        }

        public async Task<ResponseMensaje> Insertar(Ent_Empleado ent_Empleado)
        {
            string BaseUri = options.Value.Url.ToString();
            ResponseMensaje responseMensaje = new ResponseMensaje();

            try
            {
                using (HttpClient _httpClient = new HttpClient())
                {
                    _httpClient.BaseAddress = new Uri(BaseUri);
                    string stringData = Newtonsoft.Json.JsonConvert.SerializeObject(ent_Empleado);
                    HttpContent content = new StringContent(stringData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = _httpClient.PostAsync("Inserta", content).GetAwaiter().GetResult();

                    string strResponse = await response.Content.ReadAsStringAsync();
                    responseMensaje = JsonConvert.DeserializeObject<ResponseMensaje>(strResponse);
                }
            }
            catch (Exception ex)
            {
                responseMensaje = new ResponseMensaje
                {
                    codigo = "00",
                    mensaje = ex.Message.ToString()
                };
                //throw;
            }

            return responseMensaje;
        }

        public async Task<List<Ent_Empleado>> Listado()
        {
            string BaseUri = options.Value.Url.ToString();
            List<Ent_Empleado> lst_entEmpleados = new List<Ent_Empleado>();

            try
            {
                using (HttpClient _httpClient = new HttpClient())
                {
                    _httpClient.BaseAddress = new Uri(BaseUri);
                    HttpResponseMessage response = _httpClient.GetAsync("Listado").GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        var JsonResultado = await response.Content.ReadAsStringAsync();
                        if (!(JsonResultado == null))
                        {
                            lst_entEmpleados = JsonConvert.DeserializeObject<List<Ent_Empleado>>(JsonResultado);
                        }
                        else
                        {
                            lst_entEmpleados = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //throw;
                lst_entEmpleados = null;
            }

            return lst_entEmpleados;
        }
    }
}
