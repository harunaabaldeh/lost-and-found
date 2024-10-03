<script setup lang="ts"></script>
<template>
  <section class="bg-blue-100 py-16">
    <div class="container mx-auto text-center">
      <h1 class="text-4xl font-bold text-gray-800 mb-4">
        Find Your Lost Documents Effortlessly
      </h1>
      <p class="text-lg text-gray-600 mb-6">
        Easily search for or submit lost documents to help you find what you’ve
        lost. Simplifying the search process for your lost items has never been
        easier!
      </p>
      <RouterLink to="/submit-missing-document">
        <button
          class="bg-blue-500 text-white px-6 py-2 rounded-full hover:bg-blue-600"
        >
          Get Started
        </button>
      </RouterLink>
    </div>
  </section>
</template>

<style scoped>
/* Add specific styling if needed */
</style>
