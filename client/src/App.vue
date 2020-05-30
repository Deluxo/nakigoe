<template>
  <section id="app" class="flex container mx-auto">
    <section v-if="loggedIn">
      <Register />
    </section>

    <main v-else class="flex w-full">
      <Navigation class="w-1/5 bg-gray-300" />

      <section class="w-4/5 bg-gray-100">
        <router-view />
      </section>
    </main>
  </section>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import Navigation from "@/components/navigation.vue";
import Register from "@/components/auth/register.vue";

@Component({
  components: {
    Navigation,
    Register,
  },
})
export default class Main extends Vue {
  loggedIn = false;
}
</script>
