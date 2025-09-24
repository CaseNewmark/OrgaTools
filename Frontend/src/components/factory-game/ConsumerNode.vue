<script setup lang="ts">
import type { ConsumerNodeData } from '@/models/factory-game/ConsumerNodeData'
import BaseNode from './BaseNode.vue'

defineProps<{
  data: ConsumerNodeData
}>()
</script>

<template>
  <BaseNode :name="data.name">
    <template #icon>
      <i class="pi pi-shopping-cart"></i>
    </template>
  </BaseNode>
</template>
