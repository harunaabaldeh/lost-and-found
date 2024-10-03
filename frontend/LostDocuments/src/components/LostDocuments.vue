<script setup lang="ts">
import { onMounted, ref } from "vue";
import { LostDocument } from "../models/lostDocument";
import agent from "../api/agent";

const lostDocuments = ref<LostDocument[]>([]);

async function loadLostDocuments() {
  const response = await agent.get<LostDocument[]>("api/documents");

  lostDocuments.value = response.data;
}

onMounted(() => {
  loadLostDocuments();
});
</script>
<template>
  <div
    class="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 xl:grid-cols-5 2xl:grid-cols-6 gap-4"
  >
    <div
      v-for="lostDocument in lostDocuments"
      :key="lostDocument.id"
      class="bg-white shadow-md rounded-lg p-4"
    >
      <h2 class="text-lg font-bold mb-2">{{ lostDocument.type }}</h2>
      <p class="text-gray-600 mb-4">{{ lostDocument.description }}</p>
    </div>
  </div>
  <div class="flex justify-center mt-4">
    <button class="btn btn-primary">Load More</button>
  </div>
</template>
<style scoped></style>
