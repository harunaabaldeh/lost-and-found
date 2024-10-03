<template>
  <section
    class="flex items-center justify-center min-h-screen bg-gray-100 p-6"
  >
    <div class="bg-white p-6 rounded-lg shadow-lg w-full max-w-2xl">
      <h2 class="text-3xl font-bold text-center mb-6 text-gray-800">
        Report Missing Document
      </h2>
      <form
        @submit.prevent="handleSubmit"
        class="grid grid-cols-1 md:grid-cols-2 gap-4"
      >
        <div class="flex flex-col">
          <label
            for="document-type"
            class="block text-gray-700 font-medium mb-1"
          >
            Document Type
          </label>
          <select
            id="document-type"
            v-model="documentType"
            required
            class="mt-1 block w-full p-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500 text-sm"
          >
            <option value="" disabled>Select a type</option>
            <option value="Passport">Passport</option>
            <option value="Driver's License">Driver's License</option>
            <option value="ID Card">ID Card</option>
            <option value="Birth Certificate">Birth Certificate</option>
            <option value="Other">Other</option>
          </select>
        </div>

        <div class="flex flex-col">
          <label
            for="document-number"
            class="block text-gray-700 font-medium mb-1"
          >
            Document Number
          </label>
          <input
            type="text"
            id="document-number"
            v-model="number"
            required
            class="mt-1 block w-full p-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500 text-sm"
            placeholder="Enter document number"
          />
        </div>

        <div class="flex flex-col">
          <label for="owner-name" class="block text-gray-700 font-medium mb-1"
            >Owner Name</label
          >
          <input
            type="text"
            id="owner-name"
            v-model="ownerName"
            required
            class="mt-1 block w-full p-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500 text-sm"
            placeholder="Enter owner's name"
          />
        </div>

        <div class="flex flex-col">
          <label
            for="owner-contact"
            class="block text-gray-700 font-medium mb-1"
            >Owner Contact</label
          >
          <input
            type="text"
            id="owner-contact"
            v-model="ownerContact"
            required
            class="mt-1 block w-full p-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500 text-sm"
            placeholder="Email or Phone Number"
          />
        </div>

        <div class="flex flex-col">
          <label for="lost-date" class="block text-gray-700 font-medium mb-1"
            >Date Lost</label
          >
          <input
            type="date"
            id="lost-date"
            v-model="lostDate"
            required
            class="mt-1 block w-full p-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500 text-sm"
          />
        </div>
        <div class="flex flex-col">
          <label for="lost-date" class="block text-gray-700 font-medium mb-1"
            >Place Found</label
          >
          <input
            type="text"
            id="place-found"
            v-model="placeFound"
            required
            class="mt-1 block w-full p-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500 text-sm"
            placeholder="Enter place found"
          />
        </div>

        <div class="flex flex-col md:col-span-2">
          <label for="description" class="block text-gray-700 font-medium mb-1"
            >Description</label
          >
          <textarea
            id="description"
            v-model="description"
            required
            class="mt-1 block w-full p-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500 text-sm"
            rows="4"
            placeholder="Provide details about the lost document"
          ></textarea>
        </div>

        <div class="flex justify-center md:col-span-2">
          <button
            type="submit"
            class="w-full bg-blue-600 text-white py-2 rounded-lg hover:bg-blue-700 transition duration-200 text-sm"
          >
            Submit
          </button>
        </div>
      </form>
      <p class="mt-4 text-center text-gray-600">
        Go back to
        <router-link to="/" class="text-blue-600 font-semibold hover:underline"
          >Home</router-link
        >
      </p>
    </div>
  </section>
</template>

<script setup lang="ts">
import { ref } from "vue";
import agent from "../api/agent";
import router from "../routes/router";

const documentType = ref("");
const number = ref("");
const ownerName = ref("");
const ownerContact = ref("");
const lostDate = ref("");
const description = ref("");
const placeFound = ref("");

async function handleSubmit() {
  const status = 0;
  const submissionData = {
    type: documentType.value,
    number: number.value,
    ownerName: ownerName.value,
    ownerContact: ownerContact.value,
    lostDate: new Date(lostDate.value).toISOString(),
    status,
    description: description.value,
    placeFound: placeFound.value,
  };

  agent
    .post("/api/documents", submissionData)
    .then((res) => {
      if (res.status === 200) {
        router.push("/");
      }
    })
    .catch((err) => {
      console.log(err);
    });
}
</script>

<style scoped>
body {
  margin: 0;
  padding: 0;
  font-family: "Arial", sans-serif;
}

h2 {
  text-shadow: 1px 1px 1px rgba(0, 0, 0, 0.1);
}
</style>
