<root dataType="Struct" type="Duality.Resources.Scene" id="129723834">
  <assetInfo />
  <globalGravity dataType="Struct" type="Duality.Vector2">
    <X dataType="Float">0</X>
    <Y dataType="Float">33</Y>
  </globalGravity>
  <serializeObj dataType="Array" type="Duality.GameObject[]" id="427169525">
    <item dataType="Struct" type="Duality.GameObject" id="3323407200">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="4109682022">
        <_items dataType="Array" type="Duality.Component[]" id="2707381120" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="3380684418">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">3323407200</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
              <Z dataType="Float">-500</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
              <Z dataType="Float">-500</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Camera" id="574826381">
            <active dataType="Bool">true</active>
            <clearColor dataType="Struct" type="Duality.Drawing.ColorRgba" />
            <farZ dataType="Float">10000</farZ>
            <focusDist dataType="Float">500</focusDist>
            <gameobj dataType="ObjectRef">3323407200</gameobj>
            <nearZ dataType="Float">50</nearZ>
            <priority dataType="Int">0</priority>
            <projection dataType="Enum" type="Duality.Drawing.ProjectionMode" name="Perspective" value="1" />
            <renderSetup dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.RenderSetup]]" />
            <renderTarget dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.RenderTarget]]" />
            <shaderParameters dataType="Struct" type="Duality.Drawing.ShaderParameterCollection" id="2347712505" custom="true">
              <body />
            </shaderParameters>
            <targetRect dataType="Struct" type="Duality.Rect">
              <H dataType="Float">1</H>
              <W dataType="Float">1</W>
              <X dataType="Float">0</X>
              <Y dataType="Float">0</Y>
            </targetRect>
            <visibilityMask dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="All" value="4294967295" />
          </item>
        </_items>
        <_size dataType="Int">2</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1286671162" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="1667619028">
            <item dataType="Type" id="2793499364" value="Duality.Components.Transform" />
            <item dataType="Type" id="4256882198" value="Duality.Components.Camera" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="2148214198">
            <item dataType="ObjectRef">3380684418</item>
            <item dataType="ObjectRef">574826381</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">3380684418</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="883813872">pBoLuJsn1UiAGpBtJmtJbw==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">Camera</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="3865760592">
      <active dataType="Bool">true</active>
      <children dataType="Struct" type="System.Collections.Generic.List`1[[Duality.GameObject]]" id="4266030070">
        <_items dataType="Array" type="Duality.GameObject[]" id="1938945760" length="4" />
        <_size dataType="Int">0</_size>
      </children>
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2294846490">
        <_items dataType="Array" type="Duality.Component[]" id="1193238212" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="3923037810">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">3865760592</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">100</X>
              <Y dataType="Float">0</Y>
              <Z dataType="Float">0</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">100</X>
              <Y dataType="Float">0</Y>
              <Z dataType="Float">0</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Physics.RigidBody" id="3400690080">
            <active dataType="Bool">true</active>
            <allowParent dataType="Bool">false</allowParent>
            <angularDamp dataType="Float">0.3</angularDamp>
            <angularVel dataType="Float">0</angularVel>
            <bodyType dataType="Enum" type="Duality.Components.Physics.BodyType" name="Static" value="0" />
            <colCat dataType="Enum" type="Duality.Components.Physics.CollisionCategory" name="Cat1" value="1" />
            <colFilter />
            <colWith dataType="Enum" type="Duality.Components.Physics.CollisionCategory" name="All" value="2147483647" />
            <explicitInertia dataType="Float">0</explicitInertia>
            <explicitMass dataType="Float">0</explicitMass>
            <fixedAngle dataType="Bool">false</fixedAngle>
            <gameobj dataType="ObjectRef">3865760592</gameobj>
            <ignoreGravity dataType="Bool">false</ignoreGravity>
            <joints />
            <linearDamp dataType="Float">0.3</linearDamp>
            <linearVel dataType="Struct" type="Duality.Vector2" />
            <revolutions dataType="Float">0</revolutions>
            <shapes dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Components.Physics.ShapeInfo]]" id="503045032">
              <_items dataType="Array" type="Duality.Components.Physics.ShapeInfo[]" id="652763820" length="4">
                <item dataType="Struct" type="Duality.Components.Physics.CircleShapeInfo" id="1867388644">
                  <density dataType="Float">1</density>
                  <friction dataType="Float">0.3</friction>
                  <parent dataType="ObjectRef">3400690080</parent>
                  <position dataType="Struct" type="Duality.Vector2" />
                  <radius dataType="Float">128</radius>
                  <restitution dataType="Float">0.3</restitution>
                  <sensor dataType="Bool">false</sensor>
                  <userTag dataType="Int">0</userTag>
                </item>
              </_items>
              <_size dataType="Int">1</_size>
            </shapes>
            <useCCD dataType="Bool">false</useCCD>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.RigidBodyRenderer" id="2624767254">
            <active dataType="Bool">true</active>
            <areaMaterial dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Default:Material:Checkerboard</contentPath>
            </areaMaterial>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">53</B>
              <G dataType="Byte">53</G>
              <R dataType="Byte">239</R>
            </colorTint>
            <customAreaMaterial />
            <customOutlineMaterial />
            <fillHollowShapes dataType="Bool">false</fillHollowShapes>
            <gameobj dataType="ObjectRef">3865760592</gameobj>
            <offset dataType="Float">0</offset>
            <outlineMaterial dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Default:Material:SolidWhite</contentPath>
            </outlineMaterial>
            <outlineWidth dataType="Float">3</outlineWidth>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group3" value="8" />
            <wrapTexture dataType="Bool">true</wrapTexture>
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3206618390" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="4275599808">
            <item dataType="ObjectRef">2793499364</item>
            <item dataType="Type" id="122706716" value="Duality.Components.Physics.RigidBody" />
            <item dataType="Type" id="4138139158" value="Duality.Components.Renderers.RigidBodyRenderer" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="290583630">
            <item dataType="ObjectRef">3923037810</item>
            <item dataType="ObjectRef">3400690080</item>
            <item dataType="ObjectRef">2624767254</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">3923037810</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="4176446812">FIodM84FRkqgKNBlttzBRw==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">Big Disk</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="2440462890">
      <active dataType="Bool">false</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1519949620">
        <_items dataType="Array" type="Duality.Component[]" id="3357675684" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="2497740108">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">2440462890</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">-512.073059</X>
              <Y dataType="Float">4.90851974</Y>
              <Z dataType="Float">0</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">-512.073059</X>
              <Y dataType="Float">4.90851974</Y>
              <Z dataType="Float">0</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Physics.RigidBody" id="1975392378">
            <active dataType="Bool">true</active>
            <allowParent dataType="Bool">false</allowParent>
            <angularDamp dataType="Float">0.3</angularDamp>
            <angularVel dataType="Float">0</angularVel>
            <bodyType dataType="Enum" type="Duality.Components.Physics.BodyType" name="Static" value="0" />
            <colCat dataType="Enum" type="Duality.Components.Physics.CollisionCategory" name="Cat1" value="1" />
            <colFilter />
            <colWith dataType="Enum" type="Duality.Components.Physics.CollisionCategory" name="All" value="2147483647" />
            <explicitInertia dataType="Float">0</explicitInertia>
            <explicitMass dataType="Float">0</explicitMass>
            <fixedAngle dataType="Bool">false</fixedAngle>
            <gameobj dataType="ObjectRef">2440462890</gameobj>
            <ignoreGravity dataType="Bool">false</ignoreGravity>
            <joints />
            <linearDamp dataType="Float">0.3</linearDamp>
            <linearVel dataType="Struct" type="Duality.Vector2" />
            <revolutions dataType="Float">0</revolutions>
            <shapes dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Components.Physics.ShapeInfo]]" id="1244681498">
              <_items dataType="Array" type="Duality.Components.Physics.ShapeInfo[]" id="2650570112" length="4">
                <item dataType="Struct" type="Duality.Components.Physics.PolyShapeInfo" id="3468285340">
                  <convexPolygons dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Vector2[]]]" id="2458537412">
                    <_items dataType="Array" type="Duality.Vector2[][]" id="2352304452" length="4" />
                    <_size dataType="Int">0</_size>
                  </convexPolygons>
                  <density dataType="Float">1</density>
                  <friction dataType="Float">0.3</friction>
                  <parent dataType="ObjectRef">1975392378</parent>
                  <restitution dataType="Float">0.3</restitution>
                  <sensor dataType="Bool">false</sensor>
                  <userTag dataType="Int">0</userTag>
                  <vertices dataType="Array" type="Duality.Vector2[]" id="2700421526">
                    <item dataType="Struct" type="Duality.Vector2">
                      <X dataType="Float">-81.74365</X>
                      <Y dataType="Float">-484.066742</Y>
                    </item>
                    <item dataType="Struct" type="Duality.Vector2">
                      <X dataType="Float">92.35681</X>
                      <Y dataType="Float">-317.072357</Y>
                    </item>
                    <item dataType="Struct" type="Duality.Vector2">
                      <X dataType="Float">89.65234</X>
                      <Y dataType="Float">310.079346</Y>
                    </item>
                    <item dataType="Struct" type="Duality.Vector2">
                      <X dataType="Float">-105.162109</X>
                      <Y dataType="Float">468.3352</Y>
                    </item>
                  </vertices>
                </item>
              </_items>
              <_size dataType="Int">1</_size>
            </shapes>
            <useCCD dataType="Bool">false</useCCD>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.RigidBodyRenderer" id="1199469552">
            <active dataType="Bool">true</active>
            <areaMaterial dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Default:Material:Checkerboard</contentPath>
            </areaMaterial>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">99</B>
              <G dataType="Byte">99</G>
              <R dataType="Byte">99</R>
            </colorTint>
            <customAreaMaterial />
            <customOutlineMaterial />
            <fillHollowShapes dataType="Bool">false</fillHollowShapes>
            <gameobj dataType="ObjectRef">2440462890</gameobj>
            <offset dataType="Float">0</offset>
            <outlineMaterial dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Default:Material:SolidWhite</contentPath>
            </outlineMaterial>
            <outlineWidth dataType="Float">3</outlineWidth>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
            <wrapTexture dataType="Bool">true</wrapTexture>
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1463865078" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="2713162014">
            <item dataType="ObjectRef">2793499364</item>
            <item dataType="ObjectRef">122706716</item>
            <item dataType="ObjectRef">4138139158</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="1348299402">
            <item dataType="ObjectRef">2497740108</item>
            <item dataType="ObjectRef">1975392378</item>
            <item dataType="ObjectRef">1199469552</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">2497740108</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="1334099694">imEsBrojRES/JR8XGOTONA==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">Left</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="2337343030">
      <active dataType="Bool">false</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="345285408">
        <_items dataType="Array" type="Duality.Component[]" id="1970991068" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="2394620248">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">2337343030</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">403.4024</X>
              <Y dataType="Float">-3.89224625</Y>
              <Z dataType="Float">0</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">403.4024</X>
              <Y dataType="Float">-3.89224625</Y>
              <Z dataType="Float">0</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Physics.RigidBody" id="1872272518">
            <active dataType="Bool">true</active>
            <allowParent dataType="Bool">false</allowParent>
            <angularDamp dataType="Float">0.3</angularDamp>
            <angularVel dataType="Float">0</angularVel>
            <bodyType dataType="Enum" type="Duality.Components.Physics.BodyType" name="Static" value="0" />
            <colCat dataType="Enum" type="Duality.Components.Physics.CollisionCategory" name="Cat1" value="1" />
            <colFilter />
            <colWith dataType="Enum" type="Duality.Components.Physics.CollisionCategory" name="All" value="2147483647" />
            <explicitInertia dataType="Float">0</explicitInertia>
            <explicitMass dataType="Float">0</explicitMass>
            <fixedAngle dataType="Bool">false</fixedAngle>
            <gameobj dataType="ObjectRef">2337343030</gameobj>
            <ignoreGravity dataType="Bool">false</ignoreGravity>
            <joints />
            <linearDamp dataType="Float">0.3</linearDamp>
            <linearVel dataType="Struct" type="Duality.Vector2" />
            <revolutions dataType="Float">0</revolutions>
            <shapes dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Components.Physics.ShapeInfo]]" id="2729309118">
              <_items dataType="Array" type="Duality.Components.Physics.ShapeInfo[]" id="71772176">
                <item dataType="Struct" type="Duality.Components.Physics.PolyShapeInfo" id="1900945212">
                  <convexPolygons dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Vector2[]]]" id="3505186628">
                    <_items dataType="Array" type="Duality.Vector2[][]" id="1400376900" length="4" />
                    <_size dataType="Int">0</_size>
                  </convexPolygons>
                  <density dataType="Float">1</density>
                  <friction dataType="Float">0.3</friction>
                  <parent dataType="ObjectRef">1872272518</parent>
                  <restitution dataType="Float">0.3</restitution>
                  <sensor dataType="Bool">false</sensor>
                  <userTag dataType="Int">0</userTag>
                  <vertices dataType="Array" type="Duality.Vector2[]" id="894557846">
                    <item dataType="Struct" type="Duality.Vector2">
                      <X dataType="Float">-57.31653</X>
                      <Y dataType="Float">-304.803162</Y>
                    </item>
                    <item dataType="Struct" type="Duality.Vector2">
                      <X dataType="Float">59.9348145</X>
                      <Y dataType="Float">-513.250061</Y>
                    </item>
                    <item dataType="Struct" type="Duality.Vector2">
                      <X dataType="Float">57.387207</X>
                      <Y dataType="Float">485.507751</Y>
                    </item>
                    <item dataType="Struct" type="Duality.Vector2">
                      <X dataType="Float">-65.78601</X>
                      <Y dataType="Float">320.882141</Y>
                    </item>
                  </vertices>
                </item>
              </_items>
              <_size dataType="Int">1</_size>
            </shapes>
            <useCCD dataType="Bool">false</useCCD>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.RigidBodyRenderer" id="1096349692">
            <active dataType="Bool">true</active>
            <areaMaterial dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Default:Material:Checkerboard</contentPath>
            </areaMaterial>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">99</B>
              <G dataType="Byte">99</G>
              <R dataType="Byte">99</R>
            </colorTint>
            <customAreaMaterial />
            <customOutlineMaterial />
            <fillHollowShapes dataType="Bool">false</fillHollowShapes>
            <gameobj dataType="ObjectRef">2337343030</gameobj>
            <offset dataType="Float">0</offset>
            <outlineMaterial dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Default:Material:SolidWhite</contentPath>
            </outlineMaterial>
            <outlineWidth dataType="Float">3</outlineWidth>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
            <wrapTexture dataType="Bool">true</wrapTexture>
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="2022623118" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="1310739442">
            <item dataType="ObjectRef">2793499364</item>
            <item dataType="ObjectRef">122706716</item>
            <item dataType="ObjectRef">4138139158</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="2527806282">
            <item dataType="ObjectRef">2394620248</item>
            <item dataType="ObjectRef">1872272518</item>
            <item dataType="ObjectRef">1096349692</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">2394620248</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="1110593730">6MjuYOx7YEaDfX2qr3JiBQ==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">Right</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="282442351">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="1001875597">
        <_items dataType="Array" type="Duality.Component[]" id="1547757862" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="339719569">
            <active dataType="Bool">true</active>
            <angle dataType="Float">1.570643</angle>
            <angleAbs dataType="Float">1.570643</angleAbs>
            <gameobj dataType="ObjectRef">282442351</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">-56.1401672</X>
              <Y dataType="Float">395.103638</Y>
              <Z dataType="Float">0</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">-56.1401672</X>
              <Y dataType="Float">395.103638</Y>
              <Z dataType="Float">0</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Physics.RigidBody" id="4112339135">
            <active dataType="Bool">true</active>
            <allowParent dataType="Bool">false</allowParent>
            <angularDamp dataType="Float">0.3</angularDamp>
            <angularVel dataType="Float">0</angularVel>
            <bodyType dataType="Enum" type="Duality.Components.Physics.BodyType" name="Static" value="0" />
            <colCat dataType="Enum" type="Duality.Components.Physics.CollisionCategory" name="Cat1" value="1" />
            <colFilter />
            <colWith dataType="Enum" type="Duality.Components.Physics.CollisionCategory" name="All" value="2147483647" />
            <explicitInertia dataType="Float">0</explicitInertia>
            <explicitMass dataType="Float">0</explicitMass>
            <fixedAngle dataType="Bool">false</fixedAngle>
            <gameobj dataType="ObjectRef">282442351</gameobj>
            <ignoreGravity dataType="Bool">false</ignoreGravity>
            <joints />
            <linearDamp dataType="Float">0.3</linearDamp>
            <linearVel dataType="Struct" type="Duality.Vector2" />
            <revolutions dataType="Float">0.499951154</revolutions>
            <shapes dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Components.Physics.ShapeInfo]]" id="567805695">
              <_items dataType="Array" type="Duality.Components.Physics.ShapeInfo[]" id="355506478">
                <item dataType="Struct" type="Duality.Components.Physics.PolyShapeInfo" id="522479440">
                  <convexPolygons dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Vector2[]]]" id="1131805628">
                    <_items dataType="Array" type="Duality.Vector2[][]" id="1135935044" length="4">
                      <item dataType="Array" type="Duality.Vector2[]" id="3938384452">
                        <item dataType="Struct" type="Duality.Vector2">
                          <X dataType="Float">-66.85243</X>
                          <Y dataType="Float">-1496.17981</Y>
                        </item>
                        <item dataType="Struct" type="Duality.Vector2">
                          <X dataType="Float">54.36926</X>
                          <Y dataType="Float">-1528.0603</Y>
                        </item>
                        <item dataType="Struct" type="Duality.Vector2">
                          <X dataType="Float">76.30279</X>
                          <Y dataType="Float">1052.58459</Y>
                        </item>
                        <item dataType="Struct" type="Duality.Vector2">
                          <X dataType="Float">-60.8585777</X>
                          <Y dataType="Float">1020.66418</Y>
                        </item>
                      </item>
                    </_items>
                    <_size dataType="Int">1</_size>
                  </convexPolygons>
                  <density dataType="Float">1</density>
                  <friction dataType="Float">0.3</friction>
                  <parent dataType="ObjectRef">4112339135</parent>
                  <restitution dataType="Float">0.3</restitution>
                  <sensor dataType="Bool">false</sensor>
                  <userTag dataType="Int">0</userTag>
                  <vertices dataType="Array" type="Duality.Vector2[]" id="271281814">
                    <item dataType="Struct" type="Duality.Vector2">
                      <X dataType="Float">-66.85243</X>
                      <Y dataType="Float">-1496.17993</Y>
                    </item>
                    <item dataType="Struct" type="Duality.Vector2">
                      <X dataType="Float">54.3692627</X>
                      <Y dataType="Float">-1528.0603</Y>
                    </item>
                    <item dataType="Struct" type="Duality.Vector2">
                      <X dataType="Float">76.30279</X>
                      <Y dataType="Float">1052.58472</Y>
                    </item>
                    <item dataType="Struct" type="Duality.Vector2">
                      <X dataType="Float">-60.8585777</X>
                      <Y dataType="Float">1020.66425</Y>
                    </item>
                  </vertices>
                </item>
              </_items>
              <_size dataType="Int">1</_size>
            </shapes>
            <useCCD dataType="Bool">false</useCCD>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.RigidBodyRenderer" id="3336416309">
            <active dataType="Bool">true</active>
            <areaMaterial dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Default:Material:Checkerboard</contentPath>
            </areaMaterial>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">99</B>
              <G dataType="Byte">99</G>
              <R dataType="Byte">99</R>
            </colorTint>
            <customAreaMaterial />
            <customOutlineMaterial />
            <fillHollowShapes dataType="Bool">false</fillHollowShapes>
            <gameobj dataType="ObjectRef">282442351</gameobj>
            <offset dataType="Float">0</offset>
            <outlineMaterial dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Default:Material:SolidWhite</contentPath>
            </outlineMaterial>
            <outlineWidth dataType="Float">3</outlineWidth>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
            <wrapTexture dataType="Bool">true</wrapTexture>
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="232271800" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="1687137767">
            <item dataType="ObjectRef">2793499364</item>
            <item dataType="ObjectRef">122706716</item>
            <item dataType="ObjectRef">4138139158</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="451304320">
            <item dataType="ObjectRef">339719569</item>
            <item dataType="ObjectRef">4112339135</item>
            <item dataType="ObjectRef">3336416309</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">339719569</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="416160677">WRTyWRo8r0CIHhrtHgK15A==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">Bottom</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="3850428899">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2323503697">
        <_items dataType="Array" type="Duality.Component[]" id="2462710766" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="3907706117">
            <active dataType="Bool">true</active>
            <angle dataType="Float">1.570643</angle>
            <angleAbs dataType="Float">1.570643</angleAbs>
            <gameobj dataType="ObjectRef">3850428899</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">-47.6340942</X>
              <Y dataType="Float">-403.733826</Y>
              <Z dataType="Float">0</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">-47.6340942</X>
              <Y dataType="Float">-403.733826</Y>
              <Z dataType="Float">0</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Physics.RigidBody" id="3385358387">
            <active dataType="Bool">true</active>
            <allowParent dataType="Bool">false</allowParent>
            <angularDamp dataType="Float">0.3</angularDamp>
            <angularVel dataType="Float">0</angularVel>
            <bodyType dataType="Enum" type="Duality.Components.Physics.BodyType" name="Static" value="0" />
            <colCat dataType="Enum" type="Duality.Components.Physics.CollisionCategory" name="Cat1" value="1" />
            <colFilter />
            <colWith dataType="Enum" type="Duality.Components.Physics.CollisionCategory" name="All" value="2147483647" />
            <explicitInertia dataType="Float">0</explicitInertia>
            <explicitMass dataType="Float">0</explicitMass>
            <fixedAngle dataType="Bool">false</fixedAngle>
            <gameobj dataType="ObjectRef">3850428899</gameobj>
            <ignoreGravity dataType="Bool">false</ignoreGravity>
            <joints />
            <linearDamp dataType="Float">0.3</linearDamp>
            <linearVel dataType="Struct" type="Duality.Vector2" />
            <revolutions dataType="Float">0.499951154</revolutions>
            <shapes dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Components.Physics.ShapeInfo]]" id="3004590419">
              <_items dataType="Array" type="Duality.Components.Physics.ShapeInfo[]" id="3496181606" length="2">
                <item dataType="Struct" type="Duality.Components.Physics.PolyShapeInfo" id="2522105728">
                  <convexPolygons dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Vector2[]]]" id="24658332">
                    <_items dataType="Array" type="Duality.Vector2[][]" id="3030418884" length="4">
                      <item dataType="Array" type="Duality.Vector2[]" id="1798205764">
                        <item dataType="Struct" type="Duality.Vector2">
                          <X dataType="Float">-75.065834</X>
                          <Y dataType="Float">-1481.29529</Y>
                        </item>
                        <item dataType="Struct" type="Duality.Vector2">
                          <X dataType="Float">81.2391</X>
                          <Y dataType="Float">-1474.89124</Y>
                        </item>
                        <item dataType="Struct" type="Duality.Vector2">
                          <X dataType="Float">103.176544</X>
                          <Y dataType="Float">1080.23413</Y>
                        </item>
                        <item dataType="Struct" type="Duality.Vector2">
                          <X dataType="Float">-59.5096169</X>
                          <Y dataType="Float">1083.399</Y>
                        </item>
                      </item>
                    </_items>
                    <_size dataType="Int">1</_size>
                  </convexPolygons>
                  <density dataType="Float">1</density>
                  <friction dataType="Float">0.3</friction>
                  <parent dataType="ObjectRef">3385358387</parent>
                  <restitution dataType="Float">0.3</restitution>
                  <sensor dataType="Bool">false</sensor>
                  <userTag dataType="Int">0</userTag>
                  <vertices dataType="Array" type="Duality.Vector2[]" id="529686550">
                    <item dataType="Struct" type="Duality.Vector2">
                      <X dataType="Float">-75.065834</X>
                      <Y dataType="Float">-1481.29529</Y>
                    </item>
                    <item dataType="Struct" type="Duality.Vector2">
                      <X dataType="Float">81.2391</X>
                      <Y dataType="Float">-1474.89136</Y>
                    </item>
                    <item dataType="Struct" type="Duality.Vector2">
                      <X dataType="Float">103.176544</X>
                      <Y dataType="Float">1080.23413</Y>
                    </item>
                    <item dataType="Struct" type="Duality.Vector2">
                      <X dataType="Float">-59.5096169</X>
                      <Y dataType="Float">1083.399</Y>
                    </item>
                  </vertices>
                </item>
              </_items>
              <_size dataType="Int">1</_size>
            </shapes>
            <useCCD dataType="Bool">false</useCCD>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.RigidBodyRenderer" id="2609435561">
            <active dataType="Bool">true</active>
            <areaMaterial dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Default:Material:Checkerboard</contentPath>
            </areaMaterial>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">99</B>
              <G dataType="Byte">99</G>
              <R dataType="Byte">99</R>
            </colorTint>
            <customAreaMaterial />
            <customOutlineMaterial />
            <fillHollowShapes dataType="Bool">false</fillHollowShapes>
            <gameobj dataType="ObjectRef">3850428899</gameobj>
            <offset dataType="Float">0</offset>
            <outlineMaterial dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Default:Material:SolidWhite</contentPath>
            </outlineMaterial>
            <outlineWidth dataType="Float">3</outlineWidth>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group0" value="1" />
            <wrapTexture dataType="Bool">true</wrapTexture>
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1434823840" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="2980382075">
            <item dataType="ObjectRef">2793499364</item>
            <item dataType="ObjectRef">122706716</item>
            <item dataType="ObjectRef">4138139158</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="4237275304">
            <item dataType="ObjectRef">3907706117</item>
            <item dataType="ObjectRef">3385358387</item>
            <item dataType="ObjectRef">2609435561</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">3907706117</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="1992624241">tPFoS1g20UeE+JvhYCRYGQ==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">Top</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="2955478277">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2481438839">
        <_items dataType="Array" type="Duality.Component[]" id="1638196622" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="3012755495">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">2955478277</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">-262.998962</X>
              <Y dataType="Float">-67.99997</Y>
              <Z dataType="Float">0</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">-262.998962</X>
              <Y dataType="Float">-67.99997</Y>
              <Z dataType="Float">0</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Physics.RigidBody" id="2490407765">
            <active dataType="Bool">true</active>
            <allowParent dataType="Bool">false</allowParent>
            <angularDamp dataType="Float">0.3</angularDamp>
            <angularVel dataType="Float">0</angularVel>
            <bodyType dataType="Enum" type="Duality.Components.Physics.BodyType" name="Static" value="0" />
            <colCat dataType="Enum" type="Duality.Components.Physics.CollisionCategory" name="Cat1" value="1" />
            <colFilter />
            <colWith dataType="Enum" type="Duality.Components.Physics.CollisionCategory" name="All" value="2147483647" />
            <explicitInertia dataType="Float">0</explicitInertia>
            <explicitMass dataType="Float">0</explicitMass>
            <fixedAngle dataType="Bool">false</fixedAngle>
            <gameobj dataType="ObjectRef">2955478277</gameobj>
            <ignoreGravity dataType="Bool">false</ignoreGravity>
            <joints />
            <linearDamp dataType="Float">0.3</linearDamp>
            <linearVel dataType="Struct" type="Duality.Vector2" />
            <revolutions dataType="Float">0</revolutions>
            <shapes dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Components.Physics.ShapeInfo]]" id="2651940693">
              <_items dataType="Array" type="Duality.Components.Physics.ShapeInfo[]" id="506419446">
                <item dataType="Struct" type="Duality.Components.Physics.CircleShapeInfo" id="1214784736">
                  <density dataType="Float">1</density>
                  <friction dataType="Float">0.3</friction>
                  <parent dataType="ObjectRef">2490407765</parent>
                  <position dataType="Struct" type="Duality.Vector2" />
                  <radius dataType="Float">30</radius>
                  <restitution dataType="Float">0.3</restitution>
                  <sensor dataType="Bool">false</sensor>
                  <userTag dataType="Int">0</userTag>
                </item>
              </_items>
              <_size dataType="Int">1</_size>
            </shapes>
            <useCCD dataType="Bool">false</useCCD>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.RigidBodyRenderer" id="1714484939">
            <active dataType="Bool">true</active>
            <areaMaterial dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Default:Material:Checkerboard</contentPath>
            </areaMaterial>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">53</B>
              <G dataType="Byte">142</G>
              <R dataType="Byte">239</R>
            </colorTint>
            <customAreaMaterial />
            <customOutlineMaterial />
            <fillHollowShapes dataType="Bool">false</fillHollowShapes>
            <gameobj dataType="ObjectRef">2955478277</gameobj>
            <offset dataType="Float">0</offset>
            <outlineMaterial dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Default:Material:SolidWhite</contentPath>
            </outlineMaterial>
            <outlineWidth dataType="Float">3</outlineWidth>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group3" value="8" />
            <wrapTexture dataType="Bool">true</wrapTexture>
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="870570304" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="2601306557">
            <item dataType="ObjectRef">2793499364</item>
            <item dataType="ObjectRef">122706716</item>
            <item dataType="ObjectRef">4138139158</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="3190024888">
            <item dataType="ObjectRef">3012755495</item>
            <item dataType="ObjectRef">2490407765</item>
            <item dataType="ObjectRef">1714484939</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">3012755495</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="3508938135">ElZSHHNqQ0Or9pK3OzKo3Q==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">Disk</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="3683176795">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="628513065">
        <_items dataType="Array" type="Duality.Component[]" id="1654974478" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="3740454013">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">3683176795</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">-175.998962</X>
              <Y dataType="Float">94.00001</Y>
              <Z dataType="Float">0</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">-175.998962</X>
              <Y dataType="Float">94.00001</Y>
              <Z dataType="Float">0</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Physics.RigidBody" id="3218106283">
            <active dataType="Bool">true</active>
            <allowParent dataType="Bool">false</allowParent>
            <angularDamp dataType="Float">0.3</angularDamp>
            <angularVel dataType="Float">0</angularVel>
            <bodyType dataType="Enum" type="Duality.Components.Physics.BodyType" name="Static" value="0" />
            <colCat dataType="Enum" type="Duality.Components.Physics.CollisionCategory" name="Cat1" value="1" />
            <colFilter />
            <colWith dataType="Enum" type="Duality.Components.Physics.CollisionCategory" name="All" value="2147483647" />
            <explicitInertia dataType="Float">0</explicitInertia>
            <explicitMass dataType="Float">0</explicitMass>
            <fixedAngle dataType="Bool">false</fixedAngle>
            <gameobj dataType="ObjectRef">3683176795</gameobj>
            <ignoreGravity dataType="Bool">false</ignoreGravity>
            <joints />
            <linearDamp dataType="Float">0.3</linearDamp>
            <linearVel dataType="Struct" type="Duality.Vector2" />
            <revolutions dataType="Float">0</revolutions>
            <shapes dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Components.Physics.ShapeInfo]]" id="808773803">
              <_items dataType="Array" type="Duality.Components.Physics.ShapeInfo[]" id="4031953142">
                <item dataType="Struct" type="Duality.Components.Physics.CircleShapeInfo" id="2222105824">
                  <density dataType="Float">1</density>
                  <friction dataType="Float">0.3</friction>
                  <parent dataType="ObjectRef">3218106283</parent>
                  <position dataType="Struct" type="Duality.Vector2" />
                  <radius dataType="Float">20</radius>
                  <restitution dataType="Float">0.3</restitution>
                  <sensor dataType="Bool">false</sensor>
                  <userTag dataType="Int">0</userTag>
                </item>
              </_items>
              <_size dataType="Int">1</_size>
            </shapes>
            <useCCD dataType="Bool">false</useCCD>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.RigidBodyRenderer" id="2442183457">
            <active dataType="Bool">true</active>
            <areaMaterial dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Default:Material:Checkerboard</contentPath>
            </areaMaterial>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">239</B>
              <G dataType="Byte">84</G>
              <R dataType="Byte">53</R>
            </colorTint>
            <customAreaMaterial />
            <customOutlineMaterial />
            <fillHollowShapes dataType="Bool">false</fillHollowShapes>
            <gameobj dataType="ObjectRef">3683176795</gameobj>
            <offset dataType="Float">0</offset>
            <outlineMaterial dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Default:Material:SolidWhite</contentPath>
            </outlineMaterial>
            <outlineWidth dataType="Float">3</outlineWidth>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group3" value="8" />
            <wrapTexture dataType="Bool">true</wrapTexture>
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3518977472" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="3059842211">
            <item dataType="ObjectRef">2793499364</item>
            <item dataType="ObjectRef">122706716</item>
            <item dataType="ObjectRef">4138139158</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="2882154872">
            <item dataType="ObjectRef">3740454013</item>
            <item dataType="ObjectRef">3218106283</item>
            <item dataType="ObjectRef">2442183457</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">3740454013</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="4064636681">vFlE5Ds2gEqPgsEZWvm9sA==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">Disk</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="974643414">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2812442496">
        <_items dataType="Array" type="Duality.Component[]" id="876962204" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="1031920632">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">974643414</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">-289.998932</X>
              <Y dataType="Float">210.999985</Y>
              <Z dataType="Float">0</Z>
            </pos>
            <posAbs dataType="Struct" type="Duality.Vector3">
              <X dataType="Float">-289.998932</X>
              <Y dataType="Float">210.999985</Y>
              <Z dataType="Float">0</Z>
            </posAbs>
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Duality.Components.Physics.RigidBody" id="509572902">
            <active dataType="Bool">true</active>
            <allowParent dataType="Bool">false</allowParent>
            <angularDamp dataType="Float">0.3</angularDamp>
            <angularVel dataType="Float">0</angularVel>
            <bodyType dataType="Enum" type="Duality.Components.Physics.BodyType" name="Static" value="0" />
            <colCat dataType="Enum" type="Duality.Components.Physics.CollisionCategory" name="Cat1" value="1" />
            <colFilter />
            <colWith dataType="Enum" type="Duality.Components.Physics.CollisionCategory" name="All" value="2147483647" />
            <explicitInertia dataType="Float">0</explicitInertia>
            <explicitMass dataType="Float">0</explicitMass>
            <fixedAngle dataType="Bool">false</fixedAngle>
            <gameobj dataType="ObjectRef">974643414</gameobj>
            <ignoreGravity dataType="Bool">false</ignoreGravity>
            <joints />
            <linearDamp dataType="Float">0.3</linearDamp>
            <linearVel dataType="Struct" type="Duality.Vector2" />
            <revolutions dataType="Float">0</revolutions>
            <shapes dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Components.Physics.ShapeInfo]]" id="1179113758">
              <_items dataType="Array" type="Duality.Components.Physics.ShapeInfo[]" id="1332969616">
                <item dataType="Struct" type="Duality.Components.Physics.CircleShapeInfo" id="1915372860">
                  <density dataType="Float">1</density>
                  <friction dataType="Float">0.3</friction>
                  <parent dataType="ObjectRef">509572902</parent>
                  <position dataType="Struct" type="Duality.Vector2" />
                  <radius dataType="Float">15</radius>
                  <restitution dataType="Float">0.3</restitution>
                  <sensor dataType="Bool">false</sensor>
                  <userTag dataType="Int">0</userTag>
                </item>
              </_items>
              <_size dataType="Int">1</_size>
            </shapes>
            <useCCD dataType="Bool">false</useCCD>
          </item>
          <item dataType="Struct" type="Duality.Components.Renderers.RigidBodyRenderer" id="4028617372">
            <active dataType="Bool">true</active>
            <areaMaterial dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Default:Material:Checkerboard</contentPath>
            </areaMaterial>
            <colorTint dataType="Struct" type="Duality.Drawing.ColorRgba">
              <A dataType="Byte">255</A>
              <B dataType="Byte">239</B>
              <G dataType="Byte">53</G>
              <R dataType="Byte">168</R>
            </colorTint>
            <customAreaMaterial />
            <customOutlineMaterial />
            <fillHollowShapes dataType="Bool">false</fillHollowShapes>
            <gameobj dataType="ObjectRef">974643414</gameobj>
            <offset dataType="Float">0</offset>
            <outlineMaterial dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Material]]">
              <contentPath dataType="String">Default:Material:SolidWhite</contentPath>
            </outlineMaterial>
            <outlineWidth dataType="Float">3</outlineWidth>
            <visibilityGroup dataType="Enum" type="Duality.Drawing.VisibilityFlag" name="Group3" value="8" />
            <wrapTexture dataType="Bool">true</wrapTexture>
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="3712279758" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="1893503314">
            <item dataType="ObjectRef">2793499364</item>
            <item dataType="ObjectRef">122706716</item>
            <item dataType="ObjectRef">4138139158</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="3345392330">
            <item dataType="ObjectRef">1031920632</item>
            <item dataType="ObjectRef">509572902</item>
            <item dataType="ObjectRef">4028617372</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">1031920632</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="1616028130">RAgxASNArkCzzB49Mx/acQ==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">Disk</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="3843916910">
      <active dataType="Bool">true</active>
      <children />
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="932211000">
        <_items dataType="Array" type="Duality.Component[]" id="2636938860" length="4">
          <item dataType="Struct" type="Soulstone.Duality.Plugins.BlueInput.InputManager" id="1184865573">
            <_x003C_Camera_x003E_k__BackingField />
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">3843916910</gameobj>
          </item>
          <item dataType="Struct" type="Soulstone.Duality.Plugins.Blue.Components.Selection.ButtonPusher" id="989842921">
            <_x003C_FreezeOnDrag_x003E_k__BackingField dataType="Bool">false</_x003C_FreezeOnDrag_x003E_k__BackingField>
            <_x003C_SelectionTrigger_x003E_k__BackingField dataType="Enum" type="Soulstone.Duality.Plugins.BlueInput.Selection.SelectionTrigger" name="MouseOver" value="2" />
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">3843916910</gameobj>
          </item>
          <item dataType="Struct" type="Soulstone.Duality.Plugins.Blue.Components.Selection.FocusKeeper" id="2165881504">
            <_x003C_FreezeOnDrag_x003E_k__BackingField dataType="Bool">false</_x003C_FreezeOnDrag_x003E_k__BackingField>
            <_x003C_SelectionTrigger_x003E_k__BackingField dataType="Enum" type="Soulstone.Duality.Plugins.BlueInput.Selection.SelectionTrigger" name="MouseDown" value="1" />
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">3843916910</gameobj>
          </item>
        </_items>
        <_size dataType="Int">3</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="1726895838" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="3590928762">
            <item dataType="Type" id="972705664" value="Soulstone.Duality.Plugins.BlueInput.InputManager" />
            <item dataType="Type" id="1142432974" value="Soulstone.Duality.Plugins.Blue.Components.Selection.ButtonPusher" />
            <item dataType="Type" id="172421404" value="Soulstone.Duality.Plugins.Blue.Components.Selection.FocusKeeper" />
          </keys>
          <values dataType="Array" type="System.Object[]" id="2383892282">
            <item dataType="ObjectRef">1184865573</item>
            <item dataType="ObjectRef">989842921</item>
            <item dataType="ObjectRef">2165881504</item>
          </values>
        </body>
      </compMap>
      <compTransform />
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="2229089786">/0CSNQgMYES5ggt9gLkXdQ==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">BlueComponents</name>
      <parent />
      <prefabLink />
    </item>
    <item dataType="Struct" type="Duality.GameObject" id="3776039890">
      <active dataType="Bool">true</active>
      <children dataType="Struct" type="System.Collections.Generic.List`1[[Duality.GameObject]]" id="2546128956">
        <_items dataType="Array" type="Duality.GameObject[]" id="447524164" length="128" />
        <_size dataType="Int">0</_size>
      </children>
      <compList dataType="Struct" type="System.Collections.Generic.List`1[[Duality.Component]]" id="2847511958">
        <_items dataType="Array" type="Duality.Component[]" id="2906415126" length="4">
          <item dataType="Struct" type="Duality.Components.Transform" id="3833317108">
            <active dataType="Bool">true</active>
            <angle dataType="Float">0</angle>
            <angleAbs dataType="Float">0</angleAbs>
            <gameobj dataType="ObjectRef">3776039890</gameobj>
            <ignoreParent dataType="Bool">false</ignoreParent>
            <pos dataType="Struct" type="Duality.Vector3" />
            <posAbs dataType="Struct" type="Duality.Vector3" />
            <scale dataType="Float">1</scale>
            <scaleAbs dataType="Float">1</scaleAbs>
          </item>
          <item dataType="Struct" type="Soulstone.Duality.Plugins.Atlas.Testing.Boids.AgentManager" id="2439978762">
            <_parameters dataType="Struct" type="Duality.ContentRef`1[[Soulstone.Duality.Plugins.Atlas.Testing.Boids.Parameters]]">
              <contentPath dataType="String">Data\Test Scenes\Boids\Flocking.Parameters.res</contentPath>
            </_parameters>
            <_x003C_AgentPrefab_x003E_k__BackingField dataType="Struct" type="Duality.ContentRef`1[[Duality.Resources.Prefab]]">
              <contentPath dataType="String">Data\Test Scenes\Boids\Agent.Prefab.res</contentPath>
            </_x003C_AgentPrefab_x003E_k__BackingField>
            <_x003C_FillCount_x003E_k__BackingField dataType="Int">250</_x003C_FillCount_x003E_k__BackingField>
            <active dataType="Bool">true</active>
            <gameobj dataType="ObjectRef">3776039890</gameobj>
          </item>
        </_items>
        <_size dataType="Int">2</_size>
      </compList>
      <compMap dataType="Struct" type="System.Collections.Generic.Dictionary`2[[System.Type],[Duality.Component]]" id="264726760" surrogate="true">
        <header />
        <body>
          <keys dataType="Array" type="System.Object[]" id="4289439192">
            <item dataType="Type" id="3634348460" value="Soulstone.Duality.Plugins.Atlas.Testing.Boids.AgentManager" />
            <item dataType="ObjectRef">2793499364</item>
          </keys>
          <values dataType="Array" type="System.Object[]" id="1061199518">
            <item dataType="ObjectRef">2439978762</item>
            <item dataType="ObjectRef">3833317108</item>
          </values>
        </body>
      </compMap>
      <compTransform dataType="ObjectRef">3833317108</compTransform>
      <identifier dataType="Struct" type="System.Guid" surrogate="true">
        <header>
          <data dataType="Array" type="System.Byte[]" id="17809796">rw67asr6nk+LL1sSy9bblA==</data>
        </header>
        <body />
      </identifier>
      <initState dataType="Enum" type="Duality.InitState" name="Initialized" value="1" />
      <name dataType="String">Agents</name>
      <parent />
      <prefabLink />
    </item>
  </serializeObj>
  <visibilityStrategy dataType="Struct" type="Duality.Components.DefaultRendererVisibilityStrategy" id="2035693768" />
</root>
<!-- XmlFormatterBase Document Separator -->
