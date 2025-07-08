<template>
  <table class="table table-striped-columns">
    <thead>
      <tr>
        <th scope="col">Producto</th>
        <th scope="col">Cantidad</th>
        <th scope="col">Precio Unitario</th>
        <th scope="col">Ganancias Totales</th>
      </tr>
    </thead>
    <tbody>
    <tr v-for="venta in ventas" :key="venta.id">
      <td>{{ venta.producto }}</td>
      <td>{{ venta.cantidad }}</td>
      <td>{{ venta.precio }}</td>
      <td>{{ venta.totalGanacia }}</td>
    </tr>
  </tbody>
  </table>
</template>

<script setup>
import { onMounted, ref } from 'vue';
import api from '../services/api';

const ventas = ref([]);

onMounted(async () => {
  const { data } = await api.get('/ventas');
  ventas.value = data;
});
</script>
