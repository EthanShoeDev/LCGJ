 #pragma strict
 
 public var speed = 1.5;
 public var spacing = 1.0;
 private var pos : Vector3;
 
 function Start() {
     pos = transform.position;
 }
 
 function Update() {
     if (Input.GetKeyDown(KeyCode.W))
         pos.y += spacing;
     if (Input.GetKeyDown(KeyCode.S))
         pos.y -= spacing;
     if (Input.GetKeyDown(KeyCode.A))
         pos.x -= spacing;
     if (Input.GetKeyDown(KeyCode.D))
         pos.x += spacing;
 
     transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
 }