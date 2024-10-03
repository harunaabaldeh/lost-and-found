<script setup lang="ts">
import { onMounted, ref } from "vue";
import { LostDocument } from "../models/lostDocument";
import agent from "../api/agent";

const documents = ref<LostDocument[]>([]);
const searchQuery = ref("");

async function loadLostDocuments() {
  try {
    const res = await agent.get<LostDocument[]>("api/documents", {
      params: {
        search: searchQuery.value,
      },
    });

    documents.value = res.data;
  } catch (error) {
    console.log(error);
  }
}

onMounted(() => {
  loadLostDocuments();
});

async function handleSearch() {
  await loadLostDocuments();
}
</script>

<template>
  <section class="container mx-auto py-20">
    <h2 class="text-2xl font-semibold text-gray-800 text-center mb-12">
      Recent Lost Documents
    </h2>
    <div class="flex justify-center mb-4">
      <input
        @input="handleSearch"
        v-model="searchQuery"
        type="text"
        class="p-2 border border-gray-300 rounded-md"
        placeholder="Search by document type, name, etc."
      />
    </div>
    <!-- Reduced gap and adjusted padding for better spacing -->
    <div
      class="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-2 justify-center"
    >
      <div
        v-for="document in documents"
        :key="document.id"
        class="bg-white p-4 shadow-md rounded-lg max-w-sm"
      >
        <h3 class="text-xl font-semibold text-gray-800">
          {{ document.ownerName }}
        </h3>
        <p class="text-gray-600 mt-2">Type: {{ document.type }}</p>
        <p class="text-gray-600 mt-2">Lost on: {{ document.lostDate }}</p>
        <p class="text-gray-600 mt-2">Place Found: {{ document.placeFound }}</p>
        <RouterLink
          :to="{ name: 'LostDocumentDetails', params: { id: document.id } }"
        >
          <button
            class="mt-4 bg-blue-500 text-white px-4 py-2 rounded-full hover:bg-blue-600"
          >
            View Details
          </button>
        </RouterLink>
      </div>
    </div>
  </section>
</template>
