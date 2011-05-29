﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sambuca
{
    public partial class Connection
    {
        public event EH_Packet_KeepAlive KeepAlive;
        public event EH_Packet_LoginRequest LoginRequest;
        public event EH_Packet_Handshake Handshake;
        public event EH_Packet_ChatMessage ChatMessage;
        public event EH_Packet_TimeUpdate TimeUpdate;
        public event EH_Packet_EntityEquipment EntityEquipment;
        public event EH_Packet_SpawnPosition SpawnPosition;
        public event EH_Packet_UpdateHealth UpdateHealth;
        public event EH_Packet_Respawn Respawn;
        public event EH_Packet_PlayerPositionAndLook PlayerPositionAndLook;
        public event EH_Packet_Animation Animation;
        public event EH_Packet_NamedEntitySpawn NamedEntitySpawn;
        public event EH_Packet_PickupSpawn PickupSpawn;
        public event EH_Packet_AddObjectVehicle AddObjectVehicle;
        public event EH_Packet_MobSpawn MobSpawn;
        public event EH_Packet_EntityPainting EntityPainting;
        public event EH_Packet_EntityVelocity EntityVelocity;
        public event EH_Packet_DestroyEntity DestroyEntity;
        public event EH_Packet_EntityRelativeMove EntityRelativeMove;
        public event EH_Packet_EntityLookAndRelativeMove EntityLookAndRelativeMove;
        public event EH_Packet_EntityStatus EntityStatus;
        public event EH_Packet_EntityMetadata EntityMetadata;
        public event EH_Packet_PreChunk PreChunk;
        public event EH_Packet_MapChunk MapChunk;
        public event EH_Packet_MultiBlockChange MultiBlockChange;
        public event EH_Packet_BlockChange BlockChange;
        public event EH_Packet_NewInvalidState NewInvalidState;
        public event EH_Packet_SetSlot SetSlot;
        public event EH_Packet_WindowItems WindowItems;
        public event EH_Packet_DisconnectKick DisconnectKick;
        public delegate void EH_Packet_KeepAlive(object sender, Packets.KeepAlive e);
        public delegate void EH_Packet_LoginRequest(object sender, Packets.LoginRequestIncoming e);
        public delegate void EH_Packet_Handshake(object sender, Packets.HandshakeIncoming e);
        public delegate void EH_Packet_ChatMessage(object sender, Packets.ChatMessage e);
        public delegate void EH_Packet_TimeUpdate(object sender, Packets.TimeUpdate e);
        public delegate void EH_Packet_EntityEquipment(object sender, Packets.EntityEquipment e);
        public delegate void EH_Packet_SpawnPosition(object sender, Packets.SpawnPosition e);
        public delegate void EH_Packet_UpdateHealth(object sender, Packets.UpdateHealth e);
        public delegate void EH_Packet_Respawn(object sender, Packets.Respawn e);
        public delegate void EH_Packet_PlayerPositionAndLook(object sender, Packets.PlayerPositionAndLookIncoming e);
        public delegate void EH_Packet_AddObjectVehicle(object sender, Packets.AddObjectVehicle e);
        public delegate void EH_Packet_MobSpawn(object sender, Packets.MobSpawn e);
        public delegate void EH_Packet_Animation(object sender, Packets.Animation e);
        public delegate void EH_Packet_NamedEntitySpawn(object sender, Packets.NamedEntitySpawn e);
        public delegate void EH_Packet_PickupSpawn(object sender, Packets.PickupSpawn e);
        public delegate void EH_Packet_EntityPainting(object sender, Packets.EntityPainting e);
        public delegate void EH_Packet_EntityVelocity(object sender, Packets.EntityVelocity e);
        public delegate void EH_Packet_DestroyEntity(object sender, Packets.DestroyEntity e);
        public delegate void EH_Packet_EntityRelativeMove(object sender, Packets.EntityRelativeMove e);
        public delegate void EH_Packet_EntityLookAndRelativeMove(object sender, Packets.EntityLookAndRelativeMove e);
        public delegate void EH_Packet_EntityStatus(object sender, Packets.EntityStatus e);
        public delegate void EH_Packet_EntityMetadata(object sender, Packets.EntityMetadata e);
        public delegate void EH_Packet_PreChunk(object sender, Packets.PreChunk e);
        public delegate void EH_Packet_MapChunk(object sender, Packets.MapChunk e);
        public delegate void EH_Packet_MultiBlockChange(object sender, Packets.MultiBlockChange e);
        public delegate void EH_Packet_BlockChange(object sender, Packets.BlockChange e);
        public delegate void EH_Packet_NewInvalidState(object sender, Packets.NewInvalidState e);
        public delegate void EH_Packet_SetSlot(object sender, Packets.SetSlot e);
        public delegate void EH_Packet_WindowItems(object sender, Packets.WindowItems e);
        public delegate void EH_Packet_DisconnectKick(object sender, Packets.DisconnectKick e);
        protected virtual void OnPacket_KeepAlive(Packets.KeepAlive e) { if(KeepAlive != null)KeepAlive(this, e); }
        protected virtual void OnPacket_LoginRequest(Packets.LoginRequestIncoming e) { if(LoginRequest != null)LoginRequest(this, e); }
        protected virtual void OnPacket_Handshake(Packets.HandshakeIncoming e) { if(Handshake != null)Handshake(this, e); }
        protected virtual void OnPacket_ChatMessage(Packets.ChatMessage e) { if(ChatMessage != null)ChatMessage(this, e); }
        protected virtual void OnPacket_TimeUpdate(Packets.TimeUpdate e) { if(TimeUpdate != null)TimeUpdate(this, e); }
        protected virtual void OnPacket_EntityEquipment(Packets.EntityEquipment e) { if(EntityEquipment != null)EntityEquipment(this, e); }
        protected virtual void OnPacket_SpawnPosition(Packets.SpawnPosition e) { if(SpawnPosition != null)SpawnPosition(this, e); }
        protected virtual void OnPacket_UpdateHealth(Packets.UpdateHealth e) { if(UpdateHealth != null)UpdateHealth(this, e); }
        protected virtual void OnPacket_Respawn(Packets.Respawn e) { if(Respawn != null)Respawn(this, e); }
        protected virtual void OnPacket_PlayerPositionAndLook(Packets.PlayerPositionAndLookIncoming e) { if(PlayerPositionAndLook != null)PlayerPositionAndLook(this, e); }
        protected virtual void OnPacket_Animation(Packets.Animation e) { if(Animation != null)Animation(this, e); }
        protected virtual void OnPacket_NamedEntitySpawn(Packets.NamedEntitySpawn e) { if(NamedEntitySpawn != null)NamedEntitySpawn(this, e); }
        protected virtual void OnPacket_PickupSpawn(Packets.PickupSpawn e) { if(PickupSpawn != null)PickupSpawn(this, e); }
        protected virtual void OnPacket_AddObjectVehicle(Packets.AddObjectVehicle e) { if(AddObjectVehicle != null)AddObjectVehicle(this, e); }
        protected virtual void OnPacket_MobSpawn(Packets.MobSpawn e) { if(MobSpawn != null)MobSpawn(this, e); }
        protected virtual void OnPacket_EntityPainting(Packets.EntityPainting e) { if(EntityPainting != null)EntityPainting(this, e); }
        protected virtual void OnPacket_EntityVelocity(Packets.EntityVelocity e) { if(EntityVelocity != null)EntityVelocity(this, e); }
        protected virtual void OnPacket_DestroyEntity(Packets.DestroyEntity e) { if(DestroyEntity != null)DestroyEntity(this, e); }
        protected virtual void OnPacket_EntityRelativeMove(Packets.EntityRelativeMove e) { if(EntityRelativeMove != null)EntityRelativeMove(this, e); }
        protected virtual void OnPacket_EntityLookAndRelativeMove(Packets.EntityLookAndRelativeMove e) { if(EntityLookAndRelativeMove != null)EntityLookAndRelativeMove(this, e); }
        protected virtual void OnPacket_EntityStatus(Packets.EntityStatus e) { if(EntityStatus != null)EntityStatus(this, e); }
        protected virtual void OnPacket_EntityMetadata(Packets.EntityMetadata e) { if(EntityMetadata != null)EntityMetadata(this, e); }
        protected virtual void OnPacket_PreChunk(Packets.PreChunk e) { if(PreChunk != null)PreChunk(this, e); }
        protected virtual void OnPacket_MapChunk(Packets.MapChunk e) { if(MapChunk != null)MapChunk(this, e); }
        protected virtual void OnPacket_MultiBlockChange(Packets.MultiBlockChange e) { if(MultiBlockChange != null)MultiBlockChange(this, e); }
        protected virtual void OnPacket_BlockChange(Packets.BlockChange e) { if(BlockChange != null)BlockChange(this, e); }
        protected virtual void OnPacket_NewInvalidState(Packets.NewInvalidState e) { if(NewInvalidState != null)NewInvalidState(this, e); }
        protected virtual void OnPacket_SetSlot(Packets.SetSlot e) { if(SetSlot != null)SetSlot(this, e); }
        protected virtual void OnPacket_WindowItems(Packets.WindowItems e) { if(WindowItems != null)WindowItems(this, e); }
        protected virtual void OnPacket_DisconnectKick(Packets.DisconnectKick e) { if(DisconnectKick != null)DisconnectKick(this, e); }
    }
}