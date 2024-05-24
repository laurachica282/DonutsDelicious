using Datos.Models;
using System;
using System.Linq;

namespace Negocio
{
    public class AutomataService
    {
        private readonly DonasContext _context;

        public AutomataService(DonasContext context)
        {
            _context = context;
            _estadoActual = Estados.q0; // Estado inicial
            ResetearDatos();
        }

        // Definir los estados del autómata
        private enum Estados
        {
            q0, // Inicio
            q1, // Seleccionar Tamaño
            q2, // Seleccionar Tipo de Dona
            q3, // Elegir Relleno (Super)
            q4, // Elegir Cobertura (Super)
            q5, // Elegir Toppings (Super) (Opcional)
            q6, // Decidir Toppings
            q7, // Calcular Precio
            q8, // Ingresar Dinero
            q9, // Validar Pago y Calcular Cambio
            q10, // Entregar Dona
            q11 // Cancelar
        }

        // Estado actual del autómata
        private Estados _estadoActual;

        // Datos de la dona y pago
        private int _tipoDonaId;
        private int _tamanoId;
        private int _rellenoId;
        private int _coberturaId;
        private int[] _toppingsIds;
        private decimal _precio;
        private decimal _dineroIngresado;

        // Método para procesar una entrada
        public void ProcesarEntrada(char entrada)
        {
            switch (_estadoActual)
            {
                case Estados.q0:
                    if (entrada == 'a')
                    {
                        _estadoActual = Estados.q1;
                    }
                    break;
                case Estados.q1:
                    // Tamaño seleccionado, pasar al tipo de dona
                    _estadoActual = Estados.q2;
                    break;
                case Estados.q2:
                    if (entrada == 'b') // Clásica
                    {
                        _tipoDonaId = 1; // Ejemplo, el ID 1 representa "Clásica"
                        _estadoActual = Estados.q7; // Pasar a calcular precio
                        CalcularPrecio();
                    }
                    else if (entrada == 'c') // Super
                    {
                        _tipoDonaId = 2; // Ejemplo, el ID 2 representa "Super"
                        _estadoActual = Estados.q3;
                    }
                    break;
                case Estados.q3:
                    // Relleno seleccionado, pasar a cobertura
                    _estadoActual = Estados.q4;
                    break;
                case Estados.q4:
                    // Cobertura seleccionada, decidir sobre toppings
                    _estadoActual = Estados.q6;
                    break;
                case Estados.q5:
                    // Toppings seleccionados
                    _estadoActual = Estados.q7;
                    CalcularPrecio();
                    break;
                case Estados.q6:
                    // Decisión sobre toppings
                    _estadoActual = Estados.q7;
                    CalcularPrecio();
                    break;
                case Estados.q7:
                    // Precio calculado
                    _estadoActual = Estados.q8;
                    break;
                case Estados.q8:
                    // Dinero ingresado
                    _estadoActual = Estados.q9;
                    break;
                case Estados.q9:
                    // Pago validado y cambio calculado
                    _estadoActual = Estados.q10;
                    break;
                case Estados.q10:
                    EntregarDona();
                    Resetear();
                    break;
                case Estados.q11:
                    Cancelar();
                    Resetear();
                    break;
                default:
                    throw new InvalidOperationException("Estado no reconocido.");
            }
        }

        // Métodos para manejar las funciones de cada estado
        public void CalcularPrecio()
        {
            // Verificar si el tipo de dona existe
            var tipoDona = _context.DonaTipos.Find(_tipoDonaId);
            if (tipoDona == null)
            {
                throw new Exception($"Tipo de dona no encontrado: {_tipoDonaId}");
            }
            _precio = tipoDona.PrecioBase;

            // Verificar si el tamaño existe
            var tamano = _context.DonaTamaños.Find(_tamanoId);
            if (tamano == null)
            {
                throw new Exception($"Tamaño no encontrado: {_tamanoId}");
            }
            _precio += tamano.PrecioAdicional;

            if (_tipoDonaId == 2) // Super
            {
                // Verificar si el relleno existe
                var relleno = _context.DonaRellenos.Find(_rellenoId);
                if (relleno == null)
                {
                    throw new Exception($"Relleno no encontrado: {_rellenoId}");
                }
                _precio += relleno.PrecioAdicional;

                // Verificar si la cobertura existe
                var cobertura = _context.DonaCoberturas.Find(_coberturaId);
                if (cobertura == null)
                {
                    throw new Exception($"Cobertura no encontrada: {_coberturaId}");
                }
                _precio += cobertura.PrecioAdicional;

                // Verificar si los toppings existen
                foreach (var toppingId in _toppingsIds)
                {
                    var topping = _context.DonaToppings.Find(toppingId);
                    if (topping == null)
                    {
                        throw new Exception($"Topping no encontrado: {toppingId}");
                    }
                    _precio += topping.PrecioAdicional;
                }
            }
        }

        private void ValidarPagoYCalcularCambio()
        {
            if (_dineroIngresado >= _precio)
            {
                _estadoActual = Estados.q10;
            }
            else
            {
                _estadoActual = Estados.q11;
            }
        }

        private void EntregarDona()
        {
            Console.WriteLine("Dona entregada. ¡Gracias por su compra!");
            // Aquí se inserta en la base de datos
            var transaccion = new Transaccione
            {
                TipoDonaId = _tipoDonaId,
                TamanoId = _tamanoId,
                RellenoId = _rellenoId != 0 ? (int?)_rellenoId : null,
                CoberturaId = _coberturaId != 0 ? (int?)_coberturaId : null,
                Total = _precio,
                DineroIngresado = _dineroIngresado,
                Cambio = _dineroIngresado - _precio,
                Fecha = DateTime.Now
            };

            _context.Transacciones.Add(transaccion);
            _context.SaveChanges();
        }

        private void Cancelar()
        {
            Console.WriteLine("Transacción cancelada.");
        }

        // Método para obtener el estado actual
        public string ObtenerEstadoActual()
        {
            return _estadoActual.ToString();
        }

        // Método para resetear el autómata
        public void Resetear()
        {
            _estadoActual = Estados.q0;
            ResetearDatos();
        }

        private void ResetearDatos()
        {
            _tipoDonaId = 0;
            _tamanoId = 0;
            _rellenoId = 0;
            _coberturaId = 0;
            _toppingsIds = Array.Empty<int>();
            _precio = 0;
            _dineroIngresado = 0;
        }

        // Métodos públicos para ingresar datos específicos
        public void IngresarTipoDona(int tipoDonaId)
        {
            _tipoDonaId = tipoDonaId;
            if (tipoDonaId == 2) // Super
            {
                _estadoActual = Estados.q3; // Pasar a elegir relleno
            }
            else // Clásica
            {
                _estadoActual = Estados.q7; // Pasar a calcular precio y luego pago
                CalcularPrecio();
            }
        }

        public void IngresarTamano(int tamanoId)
        {
            _tamanoId = tamanoId;
            _estadoActual = Estados.q2; // Pasar a elegir tipo de dona
        }

        public void IngresarRelleno(int rellenoId)
        {
            _rellenoId = rellenoId;
            _estadoActual = Estados.q4; // Pasar a elegir cobertura
        }

        public void IngresarCobertura(int coberturaId)
        {
            _coberturaId = coberturaId;
            _estadoActual = Estados.q6; // Decidir toppings
        }

        public void IngresarToppings(int[] toppingsIds)
        {
            _toppingsIds = toppingsIds;
            _estadoActual = Estados.q7;
            CalcularPrecio();
        }

        public void IngresarDinero(decimal dinero)
        {
            _dineroIngresado = dinero;
            ValidarPagoYCalcularCambio();
        }

        public decimal ObtenerPrecio()
        {
            return _precio;
        }

        public decimal ObtenerCambio()
        {
            return _dineroIngresado - _precio;
        }

        public int ObtenerTipoDona()
        {
            return _tipoDonaId;
        }

        public int ObtenerRellenoId()
        {
            return _rellenoId;
        }

        public int ObtenerCoberturaId()
        {
            return _coberturaId;
        }

        public int[] ObtenerToppingsIds()
        {
            return _toppingsIds;
        }
    }
}
