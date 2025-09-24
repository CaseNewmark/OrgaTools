<script setup lang="ts">
import { Handle, Position } from '@vue-flow/core'

defineProps<{
  name: string
}>()
</script>

<template>
  <div class="base-node">
    <div class="icon-container">
      <slot name="icon"></slot>
    </div>
    <div class="name">{{ name }}</div>
    <Handle type="target" :position="Position.Left" />
    <Handle type="source" :position="Position.Right" />
  </div>
</template>

<style scoped>
.base-node {
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 4px;
  padding: 10px;
  border-radius: 50%;
  width: 80px;
  height: 80px;
  justify-content: center;
  border: 2px solid #777;
  background-color: white;
}

.icon-container {
  font-size: 24px;
}

.name {
  font-size: 12px;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  max-width: 100%;
}
</style>
