﻿<root dataType="Struct" type="Duality.Resources.Prefab" id="129723834">
  <assetInfo dataType="Struct" type="Duality.Editor.AssetManagement.AssetInfo" id="427169525">
    <customData />
    <importerId />
    <sourceFileHint />
  </assetInfo>
  <objTree dataType="Struct" type="Duality.GameObject" id="3674566994">
    <active dataType="Bool">true</active>
    <children />
    <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="3213413685">
      <_items dataType="Array" type="Duality.Component[]" id="4221406198" length="4">
        <item dataType="Struct" type="Duality.Components.Transform" id="3731844212">
          <active dataType="Bool">true</active>
          <angle dataType="Float">0</angle>
          <angleAbs dataType="Float">0</angleAbs>
          <gameobj dataType="ObjectRef">3674566994</gameobj>
          <ignoreParent dataType="Bool">false</ignoreParent>
          <pos dataType="Struct" type="Duality.Vector3" />
          <posAbs dataType="Struct" type="Duality.Vector3" />
          <scale dataType="Float">0.2</scale>
          <scaleAbs dataType="Float">0.2</scaleAbs>
        </item>
        <item dataType="Struct" type="Duality.Components.Renderers.SpriteRenderer" id="848218978">
          <active dataType="Bool">true</active>
          <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
            <A dataType="Byte">255</A>
            <B dataType="Byte">255</B>
            <G dataType="Byte">255</G>
            <R dataType="Byte">255</R>
          </colorTint>
          <customMat />
          <flipMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+FlipMode" name="None" value="0" />
          <gameobj dataType="ObjectRef">3674566994</gameobj>
          <offset dataType="Float">0</offset>
          <pixelGrid dataType="Bool">false</pixelGrid>
          <rect dataType="Struct" type="Duality.Rect">
            <H dataType="Float">34</H>
            <W dataType="Float">32</W>
            <X dataType="Float">-16</X>
            <Y dataType="Float">-17</Y>
          </rect>
          <rectMode dataType="Enum" type="Duality.Components.Renderers.SpriteRenderer+UVMode" name="Stretch" value="0" />
          <sharedMat dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
            <contentPath dataType="String">Data\Test Scenes\Boids\Tri.Material.res</contentPath>
          </sharedMat>
          <spriteIndex dataType="Int">-1</spriteIndex>
          <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
        </item>
        <item dataType="Struct" type="Soulstone.Duality.Plugins.Atlas.Testing.Boids.Agent" id="2714998061">
          <_x003C_LocalVisualDebug_x003E_k__BackingField dataType="Bool">false</_x003C_LocalVisualDebug_x003E_k__BackingField>
          <_x003C_NaturalColor_x003E_k__BackingField dataType="Struct" type="Duality.Drawing.ColorHsva">
            <A dataType="Float">1</A>
            <H dataType="Float">0</H>
            <S dataType="Float">1</S>
            <V dataType="Float">1</V>
          </_x003C_NaturalColor_x003E_k__BackingField>
          <_x003C_Noise_x003E_k__BackingField dataType="Struct" type="Soulstone.Duality.Plugins.Atlas.Testing.Boids.SteeringNoise" id="1858532861">
            <_duration dataType="Float">0</_duration>
            <_lastTime dataType="Float">0</_lastTime>
            <_time dataType="Float">0</_time>
            <_value dataType="Float">0</_value>
            <_x003C_MaxDuration_x003E_k__BackingField dataType="Float">3</_x003C_MaxDuration_x003E_k__BackingField>
          </_x003C_Noise_x003E_k__BackingField>
          <_x003C_SteerBias_x003E_k__BackingField dataType="Enum" type="Soulstone.Duality.Plugins.Atlas.Testing.Boids.TurnDirection" name="Left" value="1" />
          <_x003C_StuckTime_x003E_k__BackingField dataType="Float">0</_x003C_StuckTime_x003E_k__BackingField>
          <active dataType="Bool">true</active>
          <gameobj dataType="ObjectRef">3674566994</gameobj>
        </item>
      </_items>
      <_size dataType="Int">3</_size>
    </compList>
    <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1858238536" surrogate="true">
      <header />
      <body>
        <keys dataType="Array" type="System.Object[]" id="1918307103">
          <item dataType="Type" id="3780577134" value="Duality.Components.Transform" />
          <item dataType="Type" id="1465278922" value="Duality.Components.Renderers.SpriteRenderer" />
          <item dataType="Type" id="3199521118" value="Soulstone.Duality.Plugins.Atlas.Testing.Boids.Agent" />
        </keys>
        <values dataType="Array" type="System.Object[]" id="3708410400">
          <item dataType="ObjectRef">3731844212</item>
          <item dataType="ObjectRef">848218978</item>
          <item dataType="ObjectRef">2714998061</item>
        </values>
      </body>
    </compMap>
    <compTransform dataType="ObjectRef">3731844212</compTransform>
    <identifier dataType="Struct" type="System.Guid" surrogate="true">
      <header>
        <data dataType="Array" type="System.Byte[]" id="1008752013">NhbZmMlCP0ejC1T3253+YQ==</data>
      </header>
      <body />
    </identifier>
    <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
    <name dataType="String">Agent</name>
    <parent />
    <prefabLink />
  </objTree>
</root>
<!-- XmlFormatterBase Document Separator -->
