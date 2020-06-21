<template>
  <section class="w-full">
    <Login />

    <button class="register button button-transparent w-full" @click="showRegister">Register</button>

    <Modal ref="register-modal">
      <Register class="register-form" />
    </Modal>
  </section>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import Navigation from "@/components/navigation.vue";
import Register from "@/components/auth/register.vue";
import Login from "@/components/auth/login.vue";
import Modal from "@/components/ui/modal.vue";
import { Ref } from "vue-property-decorator";

@Component({
  components: {
    Navigation,
    Register,
    Modal,
    Login,
  },
})
export default class NotAuthenticated extends Vue {
  @Ref("register-modal")
  private registerModal!: Modal;

  showRegister() {
    this.registerModal.toggleShown();
  }
}
</script>

<style lang="scss">
@import "@/styles/styles.scss";

.register {
  margin-top: 10px;
}
</style>
