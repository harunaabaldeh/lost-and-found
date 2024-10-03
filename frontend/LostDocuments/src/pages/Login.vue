<template>
  <section class="flex items-center justify-center min-h-screen bg-gray-100">
    <div class="bg-white p-8 rounded-lg shadow-md w-full max-w-md">
      <h2 class="text-2xl font-bold text-center mb-6">Login</h2>
      <form @submit.prevent="handleLogin">
        <div class="mb-4">
          <label for="username" class="block text-gray-700">Username</label>
          <input
            type="text"
            id="username"
            v-model="username"
            required
            class="mt-1 block w-full p-2 border rounded-md focus:outline-none focus:ring-2 focus:ring-blue-400"
          />
        </div>
        <div class="mb-4">
          <label for="password" class="block text-gray-700">Password</label>
          <input
            type="password"
            id="password"
            v-model="password"
            required
            class="mt-1 block w-full p-2 border rounded-md focus:outline-none focus:ring-2 focus:ring-blue-400"
          />
        </div>
        <button
          type="submit"
          class="w-full bg-blue-500 text-white py-2 rounded-md hover:bg-blue-600"
        >
          Login
        </button>
        <p class="mt-4 text-center">
          Don't have an account?
          <router-link to="/register" class="text-blue-500"
            >Register</router-link
          >
        </p>
      </form>
    </div>
  </section>
</template>

<script setup lang="ts">
import { ref } from "vue";
import useUserStore from "../store/userStore";

const userStore = useUserStore();

const username = ref("");
const password = ref("");

const handleLogin = async () => {
  await userStore.login(username.value, password.value);
};
</script>

<style scoped>
/* Optional: Add any additional styles here */
</style>
