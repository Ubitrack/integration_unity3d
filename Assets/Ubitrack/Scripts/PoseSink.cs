using UnityEngine;
using System;
using System.Collections;

namespace FAR{
	
	public class PoseSink : UbiTrackComponent {
		public UbitrackEventType ubitrackEvent = UbitrackEventType.Push;
		public UbitrackRelativeToUnity relative = UbitrackRelativeToUnity.World;
	
	    
		public bool once = true;
				
		protected SimplePoseReceiver m_poseReciever = null;	
		// Use this for initialization
	    public override void utInit(SimpleFacade simpleFacade)
	    {
	        base.utInit(simpleFacade);
		
			
			
			switch(ubitrackEvent)
			{
			case UbitrackEventType.Pull:{
					throw new Exception("Pull not supported yet");				
				}
			case UbitrackEventType.Push:{
	                m_poseReciever = simpleFacade.getPushSourcePose(patternID);                

					if(m_poseReciever == null)
					{
                        throw new Exception("SimplePoseReceiver could not be set for poseID:" + patternID);
					}	                    
					break;
				}
			default:
			break;
			}    
		}
		
	    void Update()
	    { 
			switch(ubitrackEvent)
			{
			case UbitrackEventType.Push:{
	            SimplePose simplePose = UbiUnityUtils.getGameObjectPose(relative, gameObject);				
					m_poseReciever.receivePose(simplePose);
					if(once) this.enabled = false;
					break;
			}
			case UbitrackEventType.Pull:
			default:
			break;
				
			}
	    }
	
	   
	}

}
