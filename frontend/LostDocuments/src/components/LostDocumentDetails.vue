<template>
  <section class="container mx-auto py-16 px-4">
    <div class="max-w-3xl mx-auto bg-white p-8 shadow-lg rounded-lg">
      <h2 class="text-3xl font-bold text-gray-800 mb-6">
        {{ document?.ownerName }} Details
      </h2>
      <div class="mb-4">
        <p class="text-gray-600">
          <span class="font-semibold">Type: </span>{{ document?.type }}
        </p>
        <p class="text-gray-600 mt-2">
          <span class="font-semibold">Lost on: </span>{{ document?.lostDate }}
        </p>
        <p class="text-gray-600 mt-2">
          <span class="font-semibold">Document ID: </span>{{ document?.number }}
        </p>
      </div>
      <div class="bg-gray-50 p-6 rounded-lg mb-6">
        <h3 class="text-lg font-semibold text-gray-800">Description</h3>
        <p class="text-gray-700 mt-2">{{ document?.description }}</p>
      </div>
      <div class="flex justify-center space-x-4 mt-6">
        <!-- <button
          class="bg-green-500 text-white px-6 py-2 rounded-lg font-medium hover:bg-green-600"
        >
          Report Found
        </button> -->
        <button
          class="bg-blue-500 text-white px-6 py-2 rounded-lg font-medium hover:bg-blue-600"
        >
          Contact Founder
        </button>
      </div>
      <div class="mt-8 text-center">
        <router-link
          to="/"
          class="text-blue-500 hover:underline hover:text-blue-600"
        >
          ← Back to Lost Documents
        </router-link>
      </div>
    </div>
  </section>
</template>

<script setup lang="ts">
import { onMounted, ref } from "vue";
import { useRoute } from "vue-router";
import { LostDocument } from "../models/lostDocument";
import agent from "../api/agent";

const route = useRoute(); // Get the route instance
const document = ref<LostDocument>();

onMounted(() => {
  const documentId = route.params.id;

  // Fetch the document details based on the id (You can use an API here)
  // For now, we mock the document details based on the passed id.

  agent.get(`api/documents/${documentId}`).then((response) => {
    document.value = response.data;
  });
});
</script>
