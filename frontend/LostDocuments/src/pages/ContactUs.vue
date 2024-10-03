<template>
  <section
    class="flex items-center justify-center min-h-screen bg-gray-100 p-6"
  >
    <div class="bg-white p-8 rounded-lg shadow-md w-full max-w-md">
      <h1 class="text-4xl font-bold text-center mb-6">Contact Us</h1>
      <form @submit.prevent="handleSubmit">
        <div class="mb-4">
          <label for="name" class="block text-gray-700">Your Name</label>
          <input
            type="text"
            id="name"
            v-model="name"
            required
            class="mt-1 block w-full p-2 border rounded-md focus:outline-none focus:ring-2 focus:ring-blue-400"
            placeholder="Enter your name"
          />
        </div>

        <div class="mb-4">
          <label for="email" class="block text-gray-700">Your Email</label>
          <input
            type="email"
            id="email"
            v-model="email"
            required
            class="mt-1 block w-full p-2 border rounded-md focus:outline-none focus:ring-2 focus:ring-blue-400"
            placeholder="Enter your email"
          />
        </div>

        <div class="mb-4">
          <label for="message" class="block text-gray-700">Message</label>
          <textarea
            id="message"
            v-model="message"
            required
            class="mt-1 block w-full p-2 border rounded-md focus:outline-none focus:ring-2 focus:ring-blue-400"
            rows="4"
            placeholder="Write your message here"
          ></textarea>
        </div>

        <button
          type="submit"
          class="w-full bg-blue-500 text-white py-2 rounded-md hover:bg-blue-600"
        >
          Send Message
        </button>
      </form>
      <p class="mt-4 text-center">
        Go back to
        <router-link to="/" class="text-blue-500">Home</router-link>
      </p>
    </div>
  </section>
</template>

<script setup lang="ts">
import { ref } from "vue";
import { useRouter } from "vue-router";

const name = ref("");
const email = ref("");
const message = ref("");
const router = useRouter();

const handleSubmit = async () => {
  // Handle submission logic, e.g., API call to send message
  console.log("Sending message:", {
    name: name.value,
    email: email.value,
    message: message.value,
  });

  // Redirect or show success message upon successful submission
  router.push("/");
};
</script>

<style scoped>
/* Optional: Add any additional styles here */
</style>
