<template>
  <section id="app" class="flex container mx-auto">
    <NotAuthenticated v-if="!loggedIn" />

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
import { mapGetters } from "vuex";
import NotAuthenticated from "@/components/not-authenticated.vue";

@Component({
  components: {
    NotAuthenticated,
  },
  computed: {
    ...mapGetters(["isAuthenticated"]),
  },
})
export default class Main extends Vue {
  loggedIn = false;
}
</script>

<style lang="scss">
@import "@/styles/styles.scss";
</style>
