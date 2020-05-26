<template>
  <section id="app" class="flex container mx-auto">
    <Navigation class="w-1/5 bg-gray-300" />

    <main class="w-4/5 bg-gray-100">
      <router-view />
    </main>
  </section>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import Navigation from "@/components/navigation.vue";

@Component({
  components: {
    Navigation
  }
})
export default class Main extends Vue {}
</script>
