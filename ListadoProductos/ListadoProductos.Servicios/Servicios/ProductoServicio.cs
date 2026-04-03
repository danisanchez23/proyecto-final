using ListadoProductos.Servicios.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListadoProductos.Servicios.Services
{
    public class ProductoService
    {
        private List<Producto> lista;

        public event Action? OnChange;

        private void NotificarCambios() => OnChange?.Invoke();

        public ProductoService()
        {
            lista = new List<Producto>();
        }

        private int _nextId = 1;

        public async Task<List<Producto>> ListarProductos()
        {
            return lista;
        }

        public async Task<Producto?> ObtenerPorId(int id)
        {
            return lista.FirstOrDefault(p => p.Id == id);
        }

        public async Task<List<Producto>> Buscar(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino))
                return lista;

            return lista
                .Where(p => p.Nombre.Contains(termino, StringComparison.OrdinalIgnoreCase) ||
                            p.Categoria.Contains(termino, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public async Task Agregar(Producto producto)
        {
            producto.Id = _nextId++;
            lista.Add(producto);
            NotificarCambios();
        }

        public async Task Actualizar(Producto producto)
        {
            var existente = lista.FirstOrDefault(p => p.Id == producto.Id);
            if (existente != null)
            {
                existente.Nombre = producto.Nombre;
                existente.Descripcion = producto.Descripcion;
                existente.Precio = producto.Precio;
                existente.Stock = producto.Stock;
                existente.Categoria = producto.Categoria;
                existente.FechaIngreso = producto.FechaIngreso;
                NotificarCambios();
            }
        }

        public async Task Eliminar(int id)
        {
            var producto = lista.FirstOrDefault(p => p.Id == id);
            if (producto != null)
            {
                lista.Remove(producto);
                NotificarCambios();
            }
        }
    }
}