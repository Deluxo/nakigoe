<template>
  <aside>
    <nav>
      <router-link class="nav-link" to="/">
        <Icon 
          icon="add"
          text="Home"/>
      </router-link>
      <router-link class="nav-link" to="/notifications">
        <Icon 
          icon="bulb"
          text="Notifications"/>
      </router-link>
      <router-link class="nav-link" to="/messages">
        <Icon 
          icon="message"
          text="Messages"/>
      </router-link>
      <router-link class="nav-link" to="/profile">
        <Icon 
          icon="user"
          text="Profile"/>
      </router-link>
    </nav>
  </aside>
</template>

<style lang="scss">
.nav-link {
  @apply block;
  @apply pt-2;
  @apply pb-2;
}
</style>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import Icon from "@/components/ui/icon.vue";

@Component({
  components: {
    Icon,
  },
})
export default class Navigation extends Vue {}
</script>
