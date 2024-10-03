<script setup lang="ts"></script>

<template>
  <div class="bg-white shadow-md p-6 max-w-2xl mx-auto rounded-lg mt-8">
    <form class="flex space-x-4">
      <input
        type="text"
        class="flex-grow p-2 border border-gray-300 rounded-md"
        placeholder="Search by document type, name, etc."
      />
      <button
        type="submit"
        class="bg-blue-500 text-white px-4 py-2 rounded-md hover:bg-blue-600"
      >
        Search
      </button>
    </form>
  </div>
</template>

<style scoped>
/* Additional styling */
</style>
