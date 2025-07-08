<template>
  <div>
    <h2>Iniciar Sesión</h2>
    <form @submit.prevent="login">
      <div class="container text-center">
        <div class="row">
          <div class="col">
            <input v-model="username" placeholder="Usuario" required />
          </div>
          <br>
          <div class="col">
            <input v-model="password" type="password" placeholder="Contraseña" required />
          </div>
        </div>
      </div><br>   
      <button class="button" type="submit">Entrar</button>
    </form>
    <p v-if="error">{{ error }}</p>
  </div>
</template>

<script setup>
import { ref } from 'vue';
import { useRouter } from 'vue-router';
import api from '../services/api';

const username = ref('');
const password = ref('');
const error = ref('');
const router = useRouter();

const login = async () => {
  try {
    const { data } = await api.post('/Auth/login', {
      username: username.value,
      password: password.value
    });
    localStorage.setItem('token', data.token);
    router.push('/home');
  } catch (err) {
    error.value = 'Credenciales inválidas';
  }
};
</script>
