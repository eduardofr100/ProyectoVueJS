<template>
  <form @submit.prevent="crearVenta">
    <div class="col">
      <div class="mb-3 row">
        <label class="col-sm-2 col-form-label">Producto</label>
        <div class="col-sm-10">
          <input v-model="producto" required />
        </div>
      </div>
      <div class="mb-3 row">
        <label class="col-sm-2 col-form-label">Cantidad</label>
        <div class="col-sm-10">
          <input v-model.number="cantidad" type="number" required />
        </div>
      </div>
      <div class="mb-3 row">
        <label class="col-sm-2 col-form-label">Precio</label>
        <div class="col-sm-10">
          <input v-model.number="precio" type="number" required />
        </div>
      </div>
    </div>
    <button class="button" type="submit">Guardar</button>
    <p v-if="mensaje">{{ mensaje }}</p>
  </form>
</template>

<script setup>
import { ref } from 'vue';
import api from '../services/api';

const producto = ref('');
const cantidad = ref(0);
const precio = ref(0);
const mensaje = ref('');

const crearVenta = async () => {
  try {
    await api.post('/ventas', {
      producto: producto.value,
      cantidad: cantidad.value,
      precio: precio.value
    });
    mensaje.value = 'Venta registrada exitosamente';
  } catch (err) {
    mensaje.value = 'Error al guardar la venta (¿estás autenticado?)';
  }
};
</script>
