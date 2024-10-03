<script setup lang="ts">
import useUserStore from "../store/userStore";

const userStore = useUserStore();
</script>
<template>
  <nav class="bg-white shadow-md p-4">
    <div class="container mx-auto flex justify-between items-center">
      <div class="text-xl font-bold text-gray-800">Lost & Found</div>
      <ul class="flex space-x-6">
        <li>
          <RouterLink to="/" class="hover:text-blue-500"> Home </RouterLink>
        </li>
        <li>
          <RouterLink to="/about" class="hover:text-blue-500">
            About
          </RouterLink>
        </li>
        <li>
          <RouterLink to="/contact" class="hover:text-blue-500">
            Contact
          </RouterLink>
        </li>
        <template v-if="!userStore.isAuthenticated">
          <li>
            <RouterLink to="/login" class="hover:text-blue-500">
              Login
            </RouterLink>
          </li>
          <li>
            <RouterLink to="/register" class="hover:text-blue-500">
              Register
            </RouterLink>
          </li>
        </template>
        <template v-else>
          <li>
            <button @click="userStore.logout" class="hover:text-blue-500">
              Logout
            </button>
          </li>
        </template>
      </ul>
    </div>
  </nav>
</template>

<style scoped>
/* Add any specific styles if needed */
</style>
