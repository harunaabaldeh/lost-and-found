<template>
  <section class="flex items-center justify-center min-h-screen bg-gray-100">
    <div class="bg-white p-8 rounded-lg shadow-md w-full max-w-md">
      <h2 class="text-2xl font-bold text-center mb-6">Register</h2>
      <form @submit.prevent="handleRegister">
        <div class="mb-4">
          <label for="first-name" class="block text-gray-700">Full Name</label>
          <input
            type="text"
            id="full-name"
            v-model="fullName"
            required
            class="mt-1 block w-full p-2 border rounded-md focus:outline-none focus:ring-2 focus:ring-blue-400"
          />
        </div>
        <div class="mb-4">
          <label for="last-name" class="block text-gray-700">Address</label>
          <input
            type="text"
            id="address"
            v-model="address"
            required
            class="mt-1 block w-full p-2 border rounded-md focus:outline-none focus:ring-2 focus:ring-blue-400"
          />
        </div>
        <div class="mb-4">
          <label for="email" class="block text-gray-700">Username</label>
          <input
            type="text"
            id="username"
            v-model="username"
            required
            class="mt-1 block w-full p-2 border rounded-md focus:outline-none focus:ring-2 focus:ring-blue-400"
          />
        </div>
        <div class="mb-4">
          <label for="email" class="block text-gray-700">Email</label>
          <input
            type="email"
            id="email"
            v-model="email"
            required
            class="mt-1 block w-full p-2 border rounded-md focus:outline-none focus:ring-2 focus:ring-blue-400"
          />
        </div>
        <div class="mb-4">
          <label for="confirm-password" class="block text-gray-700"
            >Password</label
          >
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
          Register
        </button>
        <p class="mt-4 text-center">
          Already have an account?
          <router-link to="/login" class="text-blue-500">Login</router-link>
        </p>
      </form>
    </div>
  </section>
</template>

<script setup lang="ts">
import { ref } from "vue";
import useUserStore from "../store/userStore";
const userStore = useUserStore();

const fullName = ref("");
const address = ref("");
const username = ref("");
const email = ref("");
const password = ref("");

const handleRegister = async () => {
  await userStore.register(
    fullName.value,
    address.value,
    username.value,
    email.value,
    password.value
  );
};
</script>

<style scoped>
/* Optional: Add any additional styles here */
</style>
