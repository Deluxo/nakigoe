<template>
  <section id="app">
    <Navigation />

    <main>
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
