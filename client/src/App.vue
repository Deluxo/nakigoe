<template>
  <section id="app" class="flex container mx-auto">
    <section v-if="!loggedIn">
      <button 
        class="button"
        @click="showRegister">Register</button>
      
      <Modal ref="register-modal">
        <Register />
      </Modal>
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
import Modal from "@/components/ui/modal.vue";
import { Ref } from "vue-property-decorator";

@Component({
  components: {
    Navigation,
    Register,
    Modal,
  },
})
export default class Main extends Vue {
  loggedIn = false;

  @Ref("register-modal")
  private registerModal!: Modal;

  showRegister() {
    this.registerModal.toggleShown();
  }
}
</script>

<style lang="scss">
@import "@/styles/styles.scss";
</style>
