<template>
  <!-- TODO: People who aren't authenticated needs to be able to see pips -->
  <section id="app" class="flex container mx-auto">
    <NotAuthenticated v-if="!isAuthenticated" />

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
import Navigation from "@/components/navigation.vue";
import ImageInput from "@/components/ui/image-input.vue";

@Component({
  components: {
    NotAuthenticated,
    Navigation,
    ImageInput,
  },
  computed: {
    ...mapGetters(["isAuthenticated"]),
  },
})
export default class Main extends Vue {
  isAuthenticated!: boolean;
}
</script>

<style lang="scss">
@import "@/styles/styles.scss";
</style>
