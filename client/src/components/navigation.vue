<template>
  <aside>
    <nav>
      <router-link class="block pt-2 pb-2" to="/">Home</router-link>
      <router-link class="block pt-2 pb-2" to="/notifications">Notifications</router-link>
      <router-link class="block pt-2 pb-2" to="/messages">Messages</router-link>
      <router-link class="block pt-2 pb-2" to="/profile">Profile</router-link>
    </nav>
  </aside>
</template>

<style lang="scss"></style>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";

@Component
export default class Navigation extends Vue { }
</script>
