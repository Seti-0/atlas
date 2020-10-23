<root dataType="Struct" type="Duality.Resources.Scene" id="129723834">
  <assetInfo />
  <globalGravity dataType="Struct" type="Duality.Vector2">
    <X dataType="Float">0</X>
    <Y dataType="Float">33</Y>
  </globalGravity>
  <serializeObj dataType="Array" type="Duality.GameObject[]" id="427169525">
    <item dataType="Struct" type="Duality.GameObject" id="3808283208">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1952051534">
        <_items dataType="Array" type="Duality.Component[]" id="1778078416" length="4">
          <item dataType="Struct" type="Soulstone.Duality.Plugins.Atlas.Testing.SimpleConnect" id="1106019333">
            <_x003C_ClientName_x003E_k__BackingField dataType="String">Simple Client</_x003C_ClientName_x003E_k__BackingField>
            <_x003C_Connection_x003E_k__BackingField dataType="Enum" type="Soulstone.Duality.Plugins.Atlas.Testing.SimpleConnect+ConnectionType" name="Server" value="0" />
            <_x003C_IP_x003E_k__BackingField dataType="String">127.0.0.1</_x003C_IP_x003E_k__BackingField>
            <_x003C_Port_x003E_k__BackingField dataType="UShort">8889</_x003C_Port_x003E_k__BackingField>
            <_x003C_ServerName_x003E_k__BackingField dataType="String">Simple Server</_x003C_ServerName_x003E_k__BackingField>
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">3808283208</gameobj>
          </item>
        </_items>
        <_size dataType="Int">1</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1951469130" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="3054199308">
            <item dataType="Type" id="2741818532" value="Soulstone.Duality.Plugins.Atlas.Testing.SimpleConnect" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="1693131510">
            <item dataType="ObjectRef">1106019333</item>
          </values>
        </body>
      </compMap>
      <compTransform />
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="317616792">Y3D0A4KSJEijOQeQlkEz4Q==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">SimpleServer</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="1465931603">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="857307745">
        <_items dataType="Array" type="Duality.Component[]" id="1747358062" length="4">
          <item dataType="Struct" type="Soulstone.Duality.Plugins.BlueInput.InputManager" id="3101847562">
            <_x003C_Camera_x003E_k__BackingField />
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">1465931603</gameobj>
          </item>
          <item dataType="Struct" type="Soulstone.Duality.Plugins.Blue.Components.Selection.ButtonPusher" id="2906824910">
            <_x003C_FreezeOnDrag_x003E_k__BackingField dataType="Bool">false</_x003C_FreezeOnDrag_x003E_k__BackingField>
            <_x003C_SelectionTrigger_x003E_k__BackingField dataType="Enum" type="Soulstone.Duality.Plugins.BlueInput.Selection.SelectionTrigger" name="MouseOver" value="2" />
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">1465931603</gameobj>
          </item>
          <item dataType="Struct" type="Soulstone.Duality.Plugins.Blue.Components.Selection.FocusKeeper" id="4082863493">
            <_x003C_FreezeOnDrag_x003E_k__BackingField dataType="Bool">false</_x003C_FreezeOnDrag_x003E_k__BackingField>
            <_x003C_SelectionTrigger_x003E_k__BackingField dataType="Enum" type="Soulstone.Duality.Plugins.BlueInput.Selection.SelectionTrigger" name="MouseDown" value="1" />
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">1465931603</gameobj>
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3031967776" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="931220459">
            <item dataType="Type" id="2768420470" value="Soulstone.Duality.Plugins.BlueInput.InputManager" />
            <item dataType="Type" id="3691264282" value="Soulstone.Duality.Plugins.Blue.Components.Selection.ButtonPusher" />
            <item dataType="Type" id="1329893782" value="Soulstone.Duality.Plugins.Blue.Components.Selection.FocusKeeper" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="647218376">
            <item dataType="ObjectRef">3101847562</item>
            <item dataType="ObjectRef">2906824910</item>
            <item dataType="ObjectRef">4082863493</item>
          </values>
        </body>
      </compMap>
      <compTransform />
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="3512425185">bNtuLSjzkUaUzF9lNwg+ug==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">BlueComponents</name>
      <parent />
      <prefabLink />
    </item>
  </serializeObj>
  <visibilityStrategy dataType="Struct" type="Duality.Components.DefaultRendererVisibilityStrategy" id="2035693768" />
</root>
<!-- XmlFormatterBase Document Separator -->
